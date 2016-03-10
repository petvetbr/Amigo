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
    public class CaixaTransporteViewModel:ViewModelBase
    {
        string _caixa;
        public string Caixa
        {
            get
            {
                return _caixa;
            }
            set
            {
                if (_caixa != value)
                {
                    _caixa = value;
                    RaisePropertyChanged(nameof(Caixa));
                }
            }
        }
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
        ObservableCollection<ICaixaTransporte> _listaItens;
        public ObservableCollection<ICaixaTransporte> ListaItens
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
        public CaixaTransporteViewModel()
        {
            this.SalvarCommand = new RelayCommand(Salvar, () => Caixa != null);
            this.ExcluiCommand = new RelayCommand(Excluir, () => Caixa!=null);
            this.PesquisaCommand = new RelayCommand(Pesquisar);
            this.NovoItemCommand = new RelayCommand(CriarNovoItem);
            RefreshLista();
            ExpanderAberto = true;
            
        }

        private void CriarNovoItem()
        {
            throw new NotImplementedException();
        }

        private void Pesquisar()
        {
            throw new NotImplementedException();
        }

        private void Excluir()
        {
            throw new NotImplementedException();
        }

        private void Salvar()
        {
            throw new NotImplementedException();
        }
        
        private void RefreshLista(Expression<Func<CaixaTransporte, bool>> expression = null)
        {
            var lista = Util.Repositorio.ObterLista<CaixaTransporte>(expression);
            this.ListaItens = new ObservableCollection<ICaixaTransporte>(lista);
        }
    }
}
