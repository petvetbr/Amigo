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

        
        string ITelefone.Numero
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
