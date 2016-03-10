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

        public RelayCommand AlteraCommand { get; private set; }

        //bool podeAlterar = true;
        bool podeSalvar = true;
        bool podeExcluir = true;

        public PessoasViewModel()
        {

            Messenger.Default.Register<TipoPessoa>(this, TipoPessoaEnviada);
            this.SalvarCommand = new RelayCommand(Salvar, () => podeSalvar);
            this.ExcluiCommand = new RelayCommand(Excluir, () => podeExcluir);
            this.PesquisaCommand = new RelayCommand(Pesquisar);

            var cat = new List<KeyValuePair<int, string>>();
            cat.Add(new KeyValuePair<int, string>(1, "Fundador"));
            cat.Add(new KeyValuePair<int, string>(2, "Efetivo"));
            cat.Add(new KeyValuePair<int, string>(3, "Colaborador"));
            cat.Add(new KeyValuePair<int, string>(4, "Honorario"));
            cat.Add(new KeyValuePair<int, string>(5, "Mirim"));

            this.ListaCategorias = new ObservableCollection<KeyValuePair<int, string>>(cat);

            var tipos = new List<KeyValuePair<int, string>>();
            tipos.Add(new KeyValuePair<int, string>(1, "Normal"));
            tipos.Add(new KeyValuePair<int, string>(2, "Diretoria"));
            tipos.Add(new KeyValuePair<int, string>(3, "Voluntário"));

            this.ListaTipos = new ObservableCollection<KeyValuePair<int, string>>(tipos);


            var status = new List<KeyValuePair<int, string>>();
            status.Add(new KeyValuePair<int, string>(1, "Ativo"));
            status.Add(new KeyValuePair<int, string>(2, "Pendente"));
            status.Add(new KeyValuePair<int, string>(3, "Inativo"));

            this.ListaStatus = new ObservableCollection<KeyValuePair<int, string>>(status);
            NovoItemCommand = new RelayCommand(CriarNovoItem);
            ExpanderAberto = true;


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
            this.Pessoa = new Pessoa();
            if (Util.Repositorio.ObterLista<Pessoa>(nomeTabela: _nomeTabela).Any())
            {
                var maxAtual = Util.Repositorio.ObterLista<Pessoa>(nomeTabela: _nomeTabela).Max(p => p.Numero);
                Pessoa.Numero = ++maxAtual;
            }
            else
            {
                Pessoa.Numero = 1;
            }
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

        private void Alterar()
        {
            throw new NotImplementedException();
        }
        private void RefreshLista(Expression<Func<Pessoa, bool>> expression = null)
        {
            var lista = Util.Repositorio.ObterLista<Pessoa>(expression, _nomeTabela);
            this.ListaItens = new ObservableCollection<IRepositorio>(lista);
        }
    }
}
