using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class EmprestimoCaixaTransporteViewModel: ViewModelBase
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

       
        ObservableCollection<IEmprestimoCaixa> _listaItens;
        public ObservableCollection<IEmprestimoCaixa> ListaItens
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
        ObservableCollection<KeyValuePair<int, string>> _listaLocalizacao;
        public ObservableCollection<KeyValuePair<int, string>> ListaLocalizacao
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
        ObservableCollection<KeyValuePair<int, string>> _listaStatus;
        public ObservableCollection<KeyValuePair<int, string>> ListaStatus
        {
            get
            {
                return _listaStatus;
            }
            set
            {
                if (_listaStatus != value)
                {
                    _listaStatus = value;
                    RaisePropertyChanged(nameof(ListaStatus));
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

        IEmprestimoCaixa _emprestimo;
        public IEmprestimoCaixa Emprestimo
        {
            get
            {
                return _emprestimo;
            }
            set
            {
                if (_emprestimo != value)
                {
                    _emprestimo = value;
                    RaisePropertyChanged(nameof(Emprestimo));
                }
            }
        }



        public EmprestimoCaixaTransporteViewModel()
        {
            this.ListaLocalizacao = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaLocalizacaoCaixaTransporte());
            this.ListaSituacao = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaSituacaoCaixaTransporte());
            this.ListaStatus = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaStatusCaixaTransporte());
            this.NovoItemCommand = new RelayCommand(NovoItem, () => _emprestimo != null);
            this.SalvarCommand = new RelayCommand(Salvar, () => _emprestimo != null);
            this.ExcluiCommand = new RelayCommand(Excluir, () => _emprestimo != null);
            this.PesquisaCommand = new RelayCommand(Pesquisar);
            
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

        private void NovoItem()
        {
            throw new NotImplementedException();
        }
    }
}
