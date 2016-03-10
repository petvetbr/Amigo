using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoRepo
{
    public class LancamentoCaixa : EntidadeRepo, ILancamentoCaixa
    {
        DateTime _Data;
        public DateTime Data
        {
            get
            {
                return _Data;
            }

            set
            {
                if (_Data != value)
                {
                    _Data = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }
        string _Descricao;
        public string Descricao
        {
            get
            {
                return _Descricao;
            }

            set
            {
                if (_Descricao != value)
                {
                    _Descricao = value;
                    OnPropertyChanged(nameof(Descricao));
                }
            }
        }

        Decimal _Valor;
        public decimal Valor
        {
            get
            {
                return _Valor;
            }

            set
            {
                if (_Valor != value)
                {
                    _Valor = value;
                    OnPropertyChanged(nameof(Valor));
                }
            }
        }
    }
}
