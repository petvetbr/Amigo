using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoRepo
{
    public class FluxoCaixa : EntidadeRepo, IFluxoCaixa
    {
        int _Ano;
        public int Ano
        {
            get
            {
                return _Ano;
            }

            set
            {
                if (_Ano != value)
                {
                    _Ano = value;
                    OnPropertyChanged(nameof(Ano));
                }
            }
        }
        ObservableCollection<ILancamentoCaixa> _Lancamentos;
        public ObservableCollection<ILancamentoCaixa> Lancamentos
        {
            get
            {
                return _Lancamentos;
            }

            set
            {
                if (_Lancamentos != value)
                {
                    _Lancamentos = value;
                    OnPropertyChanged(nameof(Lancamentos));
                }
            }
        }
        int _Mes;
        public int Mes
        {
            get
            {
                return _Mes;
            }

            set
            {
                if (_Mes != value)
                {
                    _Mes = value;
                    OnPropertyChanged(nameof(Mes));
                }
            }
        }
        decimal _SaldoAnterior;
        public decimal SaldoAnterior
        {
            get
            {
                return _SaldoAnterior;
            }

            set
            {
                if (_SaldoAnterior != value)
                {
                    _SaldoAnterior = value;
                    OnPropertyChanged(nameof(SaldoAnterior));
                }
            }
        }
        
        public decimal SaldoAtual
        {
            get
            {
                return ObterSaldoAtual();
            }
          
        }

        public FluxoCaixa()
        {
            this.Lancamentos = new ObservableCollection<ILancamentoCaixa>();
        }
        private decimal ObterSaldoAtual()
        {
            var receitas = this._Lancamentos.Where(p => !p.EhDespesa.GetValueOrDefault()).Sum(p => p.Valor);
            var despesas = this._Lancamentos.Where(p => p.EhDespesa.GetValueOrDefault()).Sum(p => p.Valor);
            return this._SaldoAnterior + receitas - despesas;
        }
    }
}
