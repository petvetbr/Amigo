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
        #region Comandos
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
        #endregion
        #region Propriedades
        private TipoPessoa _tipoPessoa;
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
                    if (value == null)
                    {
                        this.Crmv = string.Empty;
                        this.CrmvUf = string.Empty;
                        return;
                    }
                    this.TelefoneSelecionado = value.Telefones.FirstOrDefault() ?? new Telefone();
                    if (_tipoPessoa == TipoPessoa.Veterinario)
                    {

                        this.Crmv = _pessoa.CamposExtras.SingleOrDefault(p =>  p.Chave?.Equals(nameof(Crmv))??false)?.Valor ??string.Empty;
                        this.CrmvUf = _pessoa.CamposExtras.SingleOrDefault (p => p.Chave?.Equals(nameof(CrmvUf)) ?? false)?.Valor ??string.Empty;
                    }
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

        ObservableCollection<string> _listaUf;
        public ObservableCollection<string> ListaUf
        {
            get
            {
                return _listaUf;
            }
            set
            {
                if (_listaUf != value)
                {
                    _listaUf = value;
                    RaisePropertyChanged(nameof(ListaUf));
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

        bool _exibirTipoPessoa;
        public bool ExibirTipoPessoa
        {
            get
            {
                return _exibirTipoPessoa;
            }
            set
            {
                if (_exibirTipoPessoa != value)
                {
                    _exibirTipoPessoa = value;
                    RaisePropertyChanged(nameof(ExibirTipoPessoa));
                }
            }
        }
        bool _exibirNomeFantasia;
        public bool ExibirNomeFantasia
        {
            get
            {
                return _exibirNomeFantasia;
            }
            set
            {
                if (_exibirNomeFantasia != value)
                {
                    _exibirNomeFantasia = value;
                    RaisePropertyChanged(nameof(ExibirNomeFantasia));
                }
            }
        }
        bool _exibirNomeRepresentante;
        public bool ExibirNomeRepresentante
        {
            get
            {
                return _exibirNomeRepresentante;
            }
            set
            {
                if (_exibirNomeRepresentante != value)
                {
                    _exibirNomeRepresentante = value;
                    RaisePropertyChanged(nameof(ExibirNomeRepresentante));
                }
            }
        }


        bool _exibirCpfCnpj;
        public bool ExibirCpfCnpj
        {
            get
            {
                return _exibirCpfCnpj;
            }
            set
            {
                if (_exibirCpfCnpj != value)
                {
                    _exibirCpfCnpj = value;
                    RaisePropertyChanged(nameof(ExibirCpfCnpj));
                }
            }
        }


        bool _exibirHomePage;
        public bool ExibirHomePage
        {
            get
            {
                return _exibirHomePage;
            }
            set
            {
                if (_exibirHomePage != value)
                {
                    _exibirHomePage = value;
                    RaisePropertyChanged(nameof(ExibirHomePage));
                }
            }
        }
        bool _exibirCategoria;
        public bool ExibirCategoria
        {
            get
            {
                return _exibirCategoria;
            }
            set
            {
                if (_exibirCategoria != value)
                {
                    _exibirCategoria = value;
                    RaisePropertyChanged(nameof(ExibirCategoria));
                }
            }
        }
        bool _exibirTipo;
        public bool ExibirTipo
        {
            get
            {
                return _exibirTipo;
            }
            set
            {
                if (_exibirTipo != value)
                {
                    _exibirTipo = value;
                    RaisePropertyChanged(nameof(ExibirTipo));
                }
            }
        }
        bool _exibirStatus;
        public bool ExibirStatus
        {
            get
            {
                return _exibirStatus;
            }
            set
            {
                if (_exibirStatus != value)
                {
                    _exibirStatus = value;
                    RaisePropertyChanged(nameof(ExibirStatus));
                }
            }
        }


        bool _exibirCrmv;
        public bool ExibirCrmv
        {
            get
            {
                return _exibirCrmv;
            }
            set
            {
                if (_exibirCrmv != value)
                {
                    _exibirCrmv = value;
                    RaisePropertyChanged(nameof(ExibirCrmv));
                }
            }
        }

        string _crmv;
        public string Crmv
        {
            get
            {
                return _crmv;
            }
            set
            {
                if (_crmv != value)
                {
                    _crmv = value;
                    RaisePropertyChanged(nameof(Crmv));
                }
            }
        }
        string _crmvUf;
        public string CrmvUf
        {
            get
            {
                return _crmvUf;
            }
            set
            {
                if (_crmvUf != value)
                {
                    _crmvUf = value;
                    RaisePropertyChanged(nameof(CrmvUf));
                }
            }
        }

        string labelResponsavel;
        public string LabelResponsavel
        {
            get
            {
                return labelResponsavel;
            }
            set
            {
                if (labelResponsavel != value)
                {
                    labelResponsavel = value;
                    RaisePropertyChanged(nameof(LabelResponsavel));
                }
            }
        }
        string labelFantasia;
        public string LabelFantasia
        {
            get
            {
                return labelFantasia;
            }
            set
            {
                if (labelFantasia != value)
                {
                    labelFantasia = value;
                    RaisePropertyChanged(nameof(LabelFantasia));
                }
            }
        }
        string labelNome;
        public string LabelNome
        {
            get
            {
                return labelNome;
            }
            set
            {
                if (labelNome != value)
                {
                    labelNome = value;
                    RaisePropertyChanged(nameof(LabelNome));
                }
            }
        }
        private bool _exibirNascimento;
        public bool ExibirNascimento
        {
            get
            {
                return _exibirNascimento;
            }
            set
            {
                if (_exibirNascimento != value)
                {
                    _exibirNascimento = value;
                    RaisePropertyChanged(nameof(ExibirNascimento));
                }
            }
        }

        #endregion


        public PessoasViewModel()
        {

            Messenger.Default.Register<TipoPessoa>(this, TipoPessoaEnviada);
            this.SalvarCommand = new RelayCommand(Salvar, () => Pessoa != null);
            this.ExcluiCommand = new RelayCommand(Excluir, () => Pessoa != null);
            this.PesquisaCommand = new RelayCommand(Pesquisar);
            this.NovoItemCommand = new RelayCommand(CriarNovoItem);
            this.LabelResponsavel = "Nome representante:";
            this.LabelFantasia = "Nome fantasia:";
            this.LabelNome = "Nome:";
            this.AdicionarTelefoneCommand = new RelayCommand(AdicionarTelefone, () => this.TelefoneSelecionado != null);
            this.RemoverTelefoneCommand = new RelayCommand(RemoverTelefone,
                () => this.TelefoneSelecionado != null
                && this.Pessoa != null
                && this.Pessoa.Telefones != null
                && this.Pessoa.Telefones.Contains(this.TelefoneSelecionado));
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
            this.ListaUf = new ObservableCollection<string>(Config.ObterListaUf());
        }

        private string _nomeTabela;
        private void TipoPessoaEnviada(TipoPessoa tipo)
        {
            _tipoPessoa = tipo;
            switch (_tipoPessoa)
            {
                case TipoPessoa.Socio:
                    {
                        _nomeTabela = "Socios";
                        this.Titulo = "Cadastro de Sócios";
                        this.ExibirStatus = true;
                        this.ExibirTipo = true;
                        this.ExibirCategoria = true;
                        this.ExibirNascimento = true;
                    }
                    break;
                case TipoPessoa.Veterinario:
                    {
                        _nomeTabela = "Veterinarios";
                        this.Titulo = "Cadastro de Veterinários";
                        this.ExibirCrmv = true;
                        this.ExibirStatus = true;
                        this.ExibirNascimento = true;
                    }
                    break;
                case TipoPessoa.Clinica:
                    {
                        _nomeTabela = "Clinicas";
                        this.Titulo = "Cadastro de Clínicas";
                        this.LabelNome = "Nome da Clínica:";
                        this.LabelResponsavel = "Responsável da Clínica:";
                        this.LabelFantasia = "Veterinário Responsável:";
                        this.ExibirStatus = true;
                        this.ExibirNomeFantasia = true;
                        this.ExibirHomePage = true;
                        this.ExibirNomeRepresentante = true;

                    }
                    break;
                case TipoPessoa.Cliente:
                    {
                        _nomeTabela = "Clientes";
                        this.Titulo = "Cadastro de Clientes";
                    }
                    break;
                case TipoPessoa.MoradorComunitario:
                    {
                        _nomeTabela = "Morador";
                        this.Titulo = "Cadastro de Moradores Comunitários";
                    }
                    break;
                case TipoPessoa.Fornecedor:
                    {
                        _nomeTabela = "Fornecedores";
                        this.Titulo = "Cadastro de Fornecedores";
                    }
                    break;
                case TipoPessoa.Entidade:
                    {
                        _nomeTabela = "Entidades";
                        this.Titulo = "Cadastro de Entidades";
                    }
                    break;
                case TipoPessoa.Parceiro:
                    {
                        _nomeTabela = "Parceiros";
                        this.Titulo = "Cadastro de Parceiros";
                    }
                    break;
                case TipoPessoa.Doador:
                    {
                        _nomeTabela = "Doadores";
                        this.Titulo = "Cadastro de Doadores";
                    }
                    break;
                case TipoPessoa.Patrocinador:
                    {
                        _nomeTabela = "Patrocinadores";
                        this.Titulo = "Cadastro de Patrocinador";
                    }
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

            if (_tipoPessoa == TipoPessoa.Veterinario)
            {
                pessoa.CamposExtras = new List<IChaveValor<string, string>>();

                this.Crmv = string.Empty;
                this.CrmvUf = string.Empty;
                pessoa.CamposExtras.Add(new ChaveValor<string, string>() { Chave = nameof(Crmv), Valor = this.Crmv });
                pessoa.CamposExtras.Add(new ChaveValor<string, string>() { Chave = nameof(CrmvUf), Valor = this.CrmvUf });
            }

            this.Pessoa = pessoa;
            ExpanderAberto = false;
        }



        private void Salvar()
        {
            if (_tipoPessoa == TipoPessoa.Veterinario)
            {
                var campoCrmv = _pessoa.CamposExtras.SingleOrDefault(p => object.Equals(p.Chave, nameof(Crmv)));
                if (campoCrmv == null)
                {
                    _pessoa.CamposExtras.Add(new ChaveValor<string, string>() { Chave = nameof(Crmv), Valor = this.Crmv });
                }
                else
                {
                    campoCrmv.Valor = this.Crmv;
                }
                var campoCrmvUf = _pessoa.CamposExtras.SingleOrDefault(p => object.Equals(p.Chave, nameof(CrmvUf)));
                if (campoCrmvUf == null)
                {
                    _pessoa.CamposExtras.Add(new ChaveValor<string, string>() { Chave = nameof(CrmvUf), Valor = this.CrmvUf });
                }
                else
                {
                    campoCrmvUf.Valor = this.CrmvUf;
                }

                
            }

            if (!Util.Repositorio.Salvar<Pessoa>(_pessoa, _nomeTabela).Key)
            {
                return;
            }
            RefreshLista();
            ExpanderAberto = true;

        }

        private void Excluir()
        {
            if (!Util.Repositorio.Apagar<Pessoa>(x => x.Id == this.Pessoa.Id))
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
            var lista = Util.Repositorio.ObterLista<Pessoa>(expression, _nomeTabela).OrderBy(p=>p.Nome);
            this.ListaItens = new ObservableCollection<IRepositorio>(lista);
        }
    }
}
