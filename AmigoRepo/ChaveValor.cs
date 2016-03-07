using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class ChaveValor<TipoChave, TipoValor> : Observable, IChaveValor<TipoChave, TipoValor>
    {
        TipoChave _chave;
        public TipoChave Chave
        {
            get
            {
                return _chave;
            }

            set
            {
                if (!value.Equals(_chave))
                {
                    _chave = value;
                    OnPropertyChanged(nameof(Chave));
                }
            }
        }
        TipoValor _valor;
        public TipoValor Valor
        {
            get
            {
                return _valor;
            }

            set
            {
                if (!value.Equals(_valor))
                {
                    _valor = value;
                    OnPropertyChanged(nameof(Valor));
                }
            }
        }
    }
}
