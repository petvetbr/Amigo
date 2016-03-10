using System;
using System.Collections.Generic;
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
        IEnumerable<ILancamentoCaixa> _Lancamentos;
        public IEnumerable<ILancamentoCaixa> Lancamentos
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
                return SaldoAnterior;
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
    }
}
