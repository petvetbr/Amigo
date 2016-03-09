using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoRepo
{
    public class Socio : Pessoa, ISocio
    {
        IChaveValor<int, string>  _categoria;
        public IChaveValor<int, string>  Categoria
        {
            get
            {
                return _categoria;
            }
            set
            {
                if (_categoria != value)
                {
                    _categoria = value;
                    OnPropertyChanged(nameof(Categoria));
                }
            }
        }

        IChaveValor<int, string> _tipo;
        public IChaveValor<int, string> Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                if (_tipo != value)
                {
                    _tipo = value;
                    OnPropertyChanged(nameof(Tipo));
                }
            }
        }

    }
}
