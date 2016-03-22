using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class BemMovelViewModel:ViewModelBase
    {

        #region Commands
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
        #endregion
        BemMovel _bem;
        public BemMovel Bem
        {
            get
            {
                return _bem;
            }
            set
            {
                if (_bem != value)
                {
                    _bem = value;
                    RaisePropertyChanged(nameof(Bem));
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
        ObservableCollection<KeyValuePair<int,string>> _listaLocalizacao;
        public ObservableCollection<KeyValuePair<int,string>>  ListaLocalizacao
        {
            get
            {
                return _listaLocalizacao;
            }
            set
            {
                if (_listaLocalizacao != value)
                {
                    _listaLocalizacao = value;
                    RaisePropertyChanged(nameof(ListaLocalizacao));
                }
            }
        }
        ObservableCollection<KeyValuePair<int, string>> _listaOrigem;
        public ObservableCollection<KeyValuePair<int, string>> ListaOrigem
        {
            get
            {
                return _listaOrigem;
            }
            set
            {
                if (_listaOrigem != value)
                {
                    _listaOrigem = value;
                    RaisePropertyChanged(nameof(ListaOrigem));
                }
            }
        }
        ObservableCollection<KeyValuePair<int, string>> _listaSituacao;
        public ObservableCollection<KeyValuePair<int, string>> ListaSituacao
        {
            get
            {
                return _listaSituacao;
            }
            set
            {
                if (_listaSituacao != value)
                {
                    _listaSituacao = value;
                    RaisePropertyChanged(nameof(ListaSituacao));
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
        ObservableCollection<BemMovel> _listaItens;
        public ObservableCollection<BemMovel> ListaItens
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
        public BemMovelViewModel()
        {
            this.ListaLocalizacao = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaLocalizacaoCaixaTransporte());
            this.ListaOrigem = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaOrigemBem());
            this.ListaTipos = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaTipoBem());
            this.ListaSituacao = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaSituacaoBem());

            this.SalvarCommand = new RelayCommand(Salvar, () => Bem != null && Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Alterar));
            this.ExcluiCommand = new RelayCommand(Excluir, () => Bem != null && Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Excluir));
            this.PesquisaCommand = new RelayCommand(Pesquisar);
            this.NovoItemCommand = new RelayCommand(CriarNovoItem, () => Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Adicionar));

            this.ExpanderAberto = true;

        }

        private void CriarNovoItem()
        {
            var Bem = new BemMovel() { DataCadastro = DateTime.Now };
            if (Util.Repositorio.ObterLista<BemMovel>().Any())
            {
                var maxAtual = Util.Repositorio.ObterLista<BemMovel>().Max(p => p.Numero);
                Bem.Numero = ++maxAtual;
            }
            else
            {
                Bem.Numero = 1;
            }
            this.Bem = Bem;
            ExpanderAberto = false;
        }

        private void Pesquisar()
        {
            if (string.IsNullOrWhiteSpace(FiltroPesquisa))
            {
                RefreshLista();
                return;
            }
            RefreshLista(x => x.Descricao.Contains(FiltroPesquisa));
        }

        private void Excluir()
        {
            if (!Util.Repositorio.Apagar<BemMovel>(x => x.Id == this.Bem.Id))
            {
                return;
            }
            this.Bem = null;
            RefreshLista();
            ExpanderAberto = true;
        }

        private void Salvar()
        {
            if (!Util.Repositorio.Salvar<BemMovel>(_bem).Key)
            {
                return;
            }
            RefreshLista();
            ExpanderAberto = true;
        }
        private void RefreshLista(Expression<Func<BemMovel, bool>> expression = null)
        {
            var lista = Util.Repositorio.ObterLista<BemMovel>(expression).OrderBy(p => p.Descricao);
            this.ListaItens = new ObservableCollection<BemMovel>(lista);
        }

    }
}
