using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class Mensalidades:EntidadeRepo, IMensalidades
    {
        ISocio _socio;
        public ISocio Socio
        {
            get
            {
                return _socio;
            }
            set
            {
                if (_socio != value)
                {
                    _socio = value;
                    OnPropertyChanged(nameof(Socio));
                }
            }
        }
        IEnumerable<IMesMensalidade> _pagamentos;
        public IEnumerable<IMesMensalidade> Pagamentos
        {
            get
            {
                return _pagamentos;
            }
            set
            {
                if (_pagamentos != value)
                {
                    _pagamentos = value;
                    OnPropertyChanged(nameof(Pagamentos));
                }
            }
        }
    }
}
