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
    public class FluxoCaixaViewModel : ViewModelBase
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

        public RelayCommand<LancamentoCaixa> ExcluiItemCommand
        {
            get;
            private set;
        }
        public RelayCommand SaldoAnteriorMudouCommand
        {
            get;
            private set;
        }
        

        FluxoCaixa _FluxoCaixaMes;
        public FluxoCaixa FluxoCaixaMes
        {
            get
            {
                return _FluxoCaixaMes;
            }

            set
            {
                if (_FluxoCaixaMes != value)
                {
                    _FluxoCaixaMes = value;
                    RaisePropertyChanged(nameof(FluxoCaixaMes));
                }
            }
        }


        ObservableCollection<int> _anos;
        public ObservableCollection<int> ListaAnos
        {
            get
            {
                return _anos;
            }
            set
            {
                if (_anos != value)
                {
                    _anos = value;
                    RaisePropertyChanged(nameof(ListaAnos));
                }
            }
        }
        ObservableCollection<KeyValuePair<int, string>> _listaMeses;
        public ObservableCollection<KeyValuePair<int, string>> ListaMeses
        {
            get
            {
                return _listaMeses;
            }
            set
            {
                if (_listaMeses != value)
                {
                    _listaMeses = value;
                    RaisePropertyChanged(nameof(ListaMeses));
                }
            }
        }
        int? _anoSelecionado;
        public int? AnoSelecionado
        {
            get
            {
                return _anoSelecionado;
            }
            set
            {
                if (_anoSelecionado != value)
                {
                    _anoSelecionado = value;
                    RaisePropertyChanged(nameof(AnoSelecionado));
                    AtualizaDados();
                }
            }
        }



        int? _MesSelecionado;
        public int? MesSelecionado
        {
            get
            {
                return _MesSelecionado;
            }
            set
            {
                if (_MesSelecionado != value)
                {
                    _MesSelecionado = value;
                    RaisePropertyChanged(nameof(MesSelecionado));
                    AtualizaDados();
                }
            }
        }
        decimal _saldoAtual;
        public decimal SaldoAtual
        {
            get
            {
                return _saldoAtual;
            }
            set
            {
                if (_saldoAtual != value)
                {
                    _saldoAtual = value;
                    RaisePropertyChanged(nameof(SaldoAtual));
                }
            }
        }

        //decimal _saldoAnterior;
        //public decimal SaldoAnterior
        //{
        //    get
        //    {
        //        return _saldoAnterior;
        //    }
        //    set
        //    {
        //        if (_saldoAnterior != value)
        //        {
        //            _saldoAnterior = value;
        //            RaisePropertyChanged(nameof(SaldoAnterior));
        //        }
        //    }
        //}

        LancamentoCaixa _lancamentoSelecionado;
        public LancamentoCaixa LancamentoSelecionado
        {
            get
            {
                return _lancamentoSelecionado;
            }
            set
            {
                if (_lancamentoSelecionado != value)
                {
                    _lancamentoSelecionado = value;
                    RaisePropertyChanged(nameof(LancamentoSelecionado));
                }
            }
        }


        public FluxoCaixaViewModel()
        {
            this.ListaAnos = new ObservableCollection<int>(Config.ObterListaAnos().Select(p => p.Key));
            this.ListaMeses = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaMeses());
            this.AnoSelecionado = DateTime.Now.Year;
            this.ExcluiItemCommand = new RelayCommand<LancamentoCaixa>(ExcluiItem);
            this.SalvarCommand = new RelayCommand(Salvar);
            this.NovoItemCommand = new RelayCommand(NovoItem, () => this._lancamentoSelecionado != null);
            this.SaldoAnteriorMudouCommand = new RelayCommand(TextoSaldoAnteriorMudou);

        }

        private void TextoSaldoAnteriorMudou()
        {
            AtualizaValores();
        }

        private void NovoItem()
        {
            var lista = this._FluxoCaixaMes.Lancamentos;
            lista.Add(_lancamentoSelecionado);
            lista.OrderBy(p => p.Data).ToList();
            this.LancamentoSelecionado = new LancamentoCaixa() { Data = DateTime.Now, EhDespesa = true };
            AtualizaValores();
        }
        private void ExcluiItem(LancamentoCaixa lancamento)
        {
            this._FluxoCaixaMes.Lancamentos.Remove(lancamento);
            AtualizaValores();
        }

        private void Salvar()
        {
            var repo = Util.Repositorio;
            repo.Salvar<FluxoCaixa>(_FluxoCaixaMes);
        }


        private void AtualizaDados()
        {
            if (this.MesSelecionado.GetValueOrDefault() == 0 || this._anoSelecionado.GetValueOrDefault() == 0)
            {
                return;
            }
            var repo = Util.Repositorio;
            var fluxo = repo.Obter<FluxoCaixa>(p => p.Ano == _anoSelecionado && p.Mes == _MesSelecionado.Value);
            if(fluxo==null)
            {
                fluxo = new FluxoCaixa() { Ano = _anoSelecionado.Value, Mes = _MesSelecionado.Value, Lancamentos = new ObservableCollection<ILancamentoCaixa>() };
            }
            this.FluxoCaixaMes = fluxo;
            this.LancamentoSelecionado = new LancamentoCaixa() { Data = DateTime.Now, EhDespesa = false };
            AtualizaValores();


        }
        private void AtualizaValores()
        {
            if (this.FluxoCaixaMes == null) return;
            var receitas = _FluxoCaixaMes.Lancamentos.Where(p => !p.EhDespesa.GetValueOrDefault()).Sum(p => p.Valor);
            var despesas = _FluxoCaixaMes.Lancamentos.Where(p => p.EhDespesa.GetValueOrDefault()).Sum(p => p.Valor);
            this.SaldoAtual = _FluxoCaixaMes.SaldoAnterior + receitas - despesas;
        }
    }
}
