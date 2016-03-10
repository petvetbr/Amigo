using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class Telefone : EntidadeRepo, ITelefone
    {
        string _Ddd;
        public string Ddd
        {
            get
            {
                return _Ddd;
            }

            set
            {
                if (value.Equals(_Ddd)) return;
                _Ddd = value;
                OnPropertyChanged(nameof(Ddd));
            }
        }
        string _numeroTelefone;
        public string NumeroTelefone
        {
            get
            {
                return _numeroTelefone;
            }
            set
            {
                if (_numeroTelefone != value)
                {
                    _numeroTelefone = value;
                    OnPropertyChanged(nameof(NumeroTelefone));
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
                if (value.Equals(_Descricao)) return;
                _Descricao = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}-{2}", this.Descricao, this.Ddd, this.NumeroTelefone);
        }


    }
}
