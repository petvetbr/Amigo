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
using System.Windows.Controls;

namespace Amigo.ViewModel
{
    public class EmprestimoCaixaTransporteViewModel : ViewModelBase
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

        public RelayCommand<SelectionChangedEventArgs> MudancaCaixaCommand
        {
            get;
            private set;
        }

        ObservableCollection<EmprestimoCaixaTransporte> _listaItens;
        public ObservableCollection<EmprestimoCaixaTransporte> ListaItens
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

        ObservableCollection<CaixaTransporte> _listaCaixasTrasnporte;
        public ObservableCollection<CaixaTransporte> ListaCaixasTransportes
        {
            get
            {
                return _listaCaixasTrasnporte;
            }
            set
            {
                if (_listaCaixasTrasnporte != value)
                {
                    _listaCaixasTrasnporte = value;
                    RaisePropertyChanged(nameof(ListaCaixasTransportes));
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

        EmprestimoCaixaTransporte _emprestimo;
        public EmprestimoCaixaTransporte Emprestimo
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
                    RaisePropertyChanged(nameof(IdentificacaoCaixa));
                }
            }
        }


        public string IdentificacaoCaixa
        {
            get
            {
                return _emprestimo?.CaixaTransporte?.Identificacao ?? null;
            }
            set
            {
                if (_emprestimo == null) return;
                if (_emprestimo.CaixaTransporte.Identificacao.Equals(value)) return;
                _emprestimo.CaixaTransporte = this.ListaCaixasTransportes.FirstOrDefault(p => p.Identificacao.Equals(value));
                RaisePropertyChanged(nameof(IdentificacaoCaixa));

            }
        }



        public EmprestimoCaixaTransporteViewModel()
        {
            CarregarListas();
            this.NovoItemCommand = new RelayCommand(NovoItem);
            this.SalvarCommand = new RelayCommand(Salvar, () => _emprestimo != null);
            this.ExcluiCommand = new RelayCommand(Excluir, () => _emprestimo != null);
            this.PesquisaCommand = new RelayCommand(Pesquisar);
            this.MudancaCaixaCommand = new RelayCommand<SelectionChangedEventArgs>(MudancaCaixa);
            RefreshLista();
            ExpanderAberto = true;

        }

        private void MudancaCaixa(SelectionChangedEventArgs e)
        {
            var ctr = e.Source as ComboBox;
            if (ctr == null) return;
            var caixa = ctr.SelectedItem as CaixaTransporte;

        }

        private void CarregarListas()
        {
            this.ListaLocalizacao = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaLocalizacaoCaixaTransporte());
            this.ListaSituacao = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaSituacaoCaixaTransporte());
            this.ListaStatus = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaStatusCaixaTransporte());
            this.ListaCaixasTransportes = new ObservableCollection<CaixaTransporte>(Util.Repositorio.ObterLista<CaixaTransporte>().OrderBy(p => p.Numero));
        }

        private void Pesquisar()
        {
            if (string.IsNullOrWhiteSpace(FiltroPesquisa))
            {
                RefreshLista();
                return;
            }
            RefreshLista(x => x.Responsavel.Contains(FiltroPesquisa));
        }
        private void RefreshLista(Func<EmprestimoCaixaTransporte, bool> expression = null)
        {
            var lista = Util.Repositorio.ObterEmprestimosCaixaTransporteComCaixa(expression).OrderBy(p => p.Responsavel);
            this.ListaItens = new ObservableCollection<EmprestimoCaixaTransporte>(lista);
        }

        private void Excluir()
        {
            if (!Util.Repositorio.Apagar<EmprestimoCaixaTransporte>(x => x.Id == this.Emprestimo.Id))
            {
                return;
            }
            this.Emprestimo = null;
            RefreshLista();
            ExpanderAberto = true;
        }

        private void Salvar()
        {
            if (!Util.Repositorio.Salvar(_emprestimo).Key)
            {
                return;
            }
            RefreshLista();
            ExpanderAberto = true;
        }

        private void NovoItem()
        {
            var emprestimo = new EmprestimoCaixaTransporte();
            if (Util.Repositorio.ObterLista<EmprestimoCaixaTransporte>().Any())
            {
                var maxAtual = Util.Repositorio.ObterLista<EmprestimoCaixaTransporte>().Max(p => p.Numero);
                emprestimo.Numero = ++maxAtual;
            }
            else
            {
                emprestimo.Numero = 1;
            }
            this.Emprestimo = emprestimo;
            ExpanderAberto = false;
        }
    }
}
