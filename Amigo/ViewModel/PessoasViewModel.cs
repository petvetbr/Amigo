using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class PessoasViewModel : ViewModelBase
    {
        public RelayCommand SalvarCommand
        {
            get;
            private set;
        }

        public RelayCommand NovoItemCommand
        {
            get;
            private set;
        }

        public RelayCommand PesquisaCommand
        {
            get;
            private set;
        }
        public RelayCommand ExcluiCommand
        {
            get;
            private set;
        }

        public RelayCommand AdicionarTelefoneCommand
        {
            get;
            private set;
        }
        public RelayCommand RemoverTelefoneCommand
        {
            get;
            private set;
        }
        Pessoa _pessoa;
        public Pessoa Pessoa
        {
            get
            {
                return _pessoa;
            }
            set
            {
                if (_pessoa != value)
                {
                    _pessoa = value;
                    RaisePropertyChanged(nameof(Pessoa));
                    this.TelefoneSelecionado = value.Telefones.FirstOrDefault() ?? new Telefone();
                }
            }
        }

        ObservableCollection<KeyValuePair<int, string>> _listaCategorias;
        public ObservableCollection<KeyValuePair<int, string>> ListaCategorias
        {
            get
            {
                return _listaCategorias;
            }
            set
            {
                if (_listaCategorias != value)
                {
                    _listaCategorias = value;
                    RaisePropertyChanged(nameof(ListaCategorias));
                }
            }
        }
        ObservableCollection<KeyValuePair<int, string>> _listaTipos;
        public ObservableCollection<KeyValuePair<int, string>> ListaTipos
        {
            get
            {
                return _listaTipos;
            }
            set
            {
                if (_listaTipos != value)
                {
                    _listaTipos = value;
                    RaisePropertyChanged(nameof(ListaTipos));
                }
            }
        }
        ObservableCollection<KeyValuePair<int, string>> _listaSatus;
        public ObservableCollection<KeyValuePair<int, string>> ListaStatus
        {
            get
            {
                return _listaSatus;
            }
            set
            {
                if (_listaSatus != value)
                {
                    _listaSatus = value;
                    RaisePropertyChanged(nameof(ListaStatus));
                }
            }
        }
        ObservableCollection<KeyValuePair<int, string>> _listaTiposTelefone;
        public ObservableCollection<KeyValuePair<int, string>> ListaTiposTelefone
        {
            get
            {
                return _listaTiposTelefone;
            }
            set
            {
                if (_listaTiposTelefone != value)
                {
                    _listaTiposTelefone = value;
                    RaisePropertyChanged(nameof(ListaTiposTelefone));
                }
            }
        }


        ObservableCollection<IRepositorio> _listaItens;
        public ObservableCollection<IRepositorio> ListaItens
        {
            get
            {
                return _listaItens;
            }
            set
            {
                if (_listaItens != value)
                {
                    _listaItens = value;
                    RaisePropertyChanged(nameof(ListaItens));
                }
            }
        }

        string _filtroPesquisa;
        public string FiltroPesquisa
        {
            get
            {
                return _filtroPesquisa;
            }
            set
            {
                if (_filtroPesquisa != value)
                {
                    _filtroPesquisa = value;
                    RaisePropertyChanged(nameof(FiltroPesquisa));
                }
            }
        }

        bool expanderAberto;
        public bool ExpanderAberto
        {
            get
            {
                return expanderAberto;
            }
            set
            {
                if (expanderAberto != value)
                {
                    expanderAberto = value;
                    RaisePropertyChanged(nameof(ExpanderAberto));
                }
            }
        }

        string _titulo;
        public string Titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                if (_titulo != value)
                {
                    _titulo = value;
                    RaisePropertyChanged(nameof(Titulo));
                }
            }
        }

        ITelefone _telefoneSelecionado;
        public ITelefone TelefoneSelecionado
        {
            get
            {
                return _telefoneSelecionado;
            }
            set
            {
                if (_telefoneSelecionado != value)
                {
                    _telefoneSelecionado = value;
                    RaisePropertyChanged(nameof(TelefoneSelecionado));
                }
            }
        }


        public PessoasViewModel()
        {

            Messenger.Default.Register<TipoPessoa>(this, TipoPessoaEnviada);
            this.SalvarCommand = new RelayCommand(Salvar, () => Pessoa != null);
            this.ExcluiCommand = new RelayCommand(Excluir, () => Pessoa != null);
            this.PesquisaCommand = new RelayCommand(Pesquisar);
            this.NovoItemCommand = new RelayCommand(CriarNovoItem);
            this.AdicionarTelefoneCommand = new RelayCommand(AdicionarTelefone, () => this.TelefoneSelecionado != null);
            this.RemoverTelefoneCommand = new RelayCommand(RemoverTelefone, 
                () => this.TelefoneSelecionado != null     && this.Pessoa.Telefones.Contains(this.TelefoneSelecionado));
            ExpanderAberto = true;

            CarregarListas();

        }

        private void AdicionarTelefone()
        {
            this.Pessoa.Telefones.Add(this.TelefoneSelecionado);
            this.TelefoneSelecionado = new Telefone();
        }

        private void RemoverTelefone()
        {
            this.Pessoa.Telefones.Remove(this.TelefoneSelecionado);
            this.TelefoneSelecionado = new Telefone();
        }

        private void CarregarListas()
        {
           

            this.ListaCategorias = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaPessoasCategoria());
            this.ListaTipos = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaPessoasTipos());
            this.ListaStatus = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaPessoasStatus());
            this.ListaTiposTelefone = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaTiposTelefone());
        }

        private string _nomeTabela;
        private void TipoPessoaEnviada(TipoPessoa tipo)
        {
            switch (tipo)
            {
                case TipoPessoa.Socio:
                    {
                        _nomeTabela = "Socios";
                        this.Titulo = "Cadastro de Sócios";
                    }
                    break;
                case TipoPessoa.Veterinario:
                    break;
                case TipoPessoa.Clinica:
                    break;
                case TipoPessoa.Cliente:
                    break;
                case TipoPessoa.MoradorComunitario:
                    break;
                case TipoPessoa.Fornecedor:
                    break;
                case TipoPessoa.Entidade:
                    break;
                case TipoPessoa.Parceiro:
                    break;
                case TipoPessoa.Doador:
                    break;
                case TipoPessoa.Patrocinador:
                    break;
                default:
                    break;
            }
            RefreshLista();
            
        }

        private void CriarNovoItem()
        {
            var pessoa = new Pessoa();
            if (Util.Repositorio.ObterLista<Pessoa>(nomeTabela: _nomeTabela).Any())
            {
                var maxAtual = Util.Repositorio.ObterLista<Pessoa>(nomeTabela: _nomeTabela).Max(p => p.Numero);
                pessoa.Numero = ++maxAtual;
            }
            else
            {
                pessoa.Numero = 1;
            }
            pessoa.DataCadastro = DateTime.Now;
            this.TelefoneSelecionado = new Telefone() { Descricao = this.ListaTiposTelefone.FirstOrDefault().Value };
            this.Pessoa = pessoa;
            ExpanderAberto = false;
        }



        private void Salvar()
        {
            if (!Util.Repositorio.Salvar<Pessoa>(this.Pessoa, _nomeTabela).Key)
            {
                return;
            }
            RefreshLista();
            ExpanderAberto = true;

        }

        private void Excluir()
        {
            if(!Util.Repositorio.Apagar<Pessoa>(x => x.Id == this.Pessoa.Id))
            {
                return;
            }
            this.Pessoa = null;
            RefreshLista();
            ExpanderAberto = true;
        }

        private void Pesquisar()
        {
            if (string.IsNullOrWhiteSpace(FiltroPesquisa))
            {
                RefreshLista();
                return;
            }
            RefreshLista(x => x.Nome.Contains(FiltroPesquisa));
        }

        private void RefreshLista(Expression<Func<Pessoa, bool>> expression = null)
        {
            var lista = Util.Repositorio.ObterLista<Pessoa>(expression, _nomeTabela);
            this.ListaItens = new ObservableCollection<IRepositorio>(lista);
        }
    }
}
