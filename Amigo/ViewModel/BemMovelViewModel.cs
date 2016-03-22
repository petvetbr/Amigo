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
        ObservableCollection<BemMovel> _listaBens;
        public ObservableCollection<BemMovel> ListaBens
        {
            get
            {
                return _listaBens;
            }
            set
            {
                if (_listaBens != value)
                {
                    _listaBens = value;
                    RaisePropertyChanged(nameof(ListaBens));
                }
            }
        }



        ObservableCollection<KeyValuePair<int,string>> _listaTipos;
        public ObservableCollection<KeyValuePair<int,string>>  ListaTipos
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
