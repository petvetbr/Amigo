using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public abstract class EntidadeRepo:Observable
    {
        Guid _repositorio;
        public Guid Repositorio
        {
            get
            {
                return _repositorio;
            }

            set
            {
                if (value.Equals(_repositorio)) return;
                _repositorio = value;
                OnPropertyChanged(nameof(Repositorio));
            }
        }
        int _numero;
        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                if (value.Equals(_numero)) return;
                _numero = value;
                OnPropertyChanged(nameof(Numero));
            }
        }
        string _observacao;
        public string Observacao
        {
            get
            {
                return _observacao;
            }

            set
            {
                if (value.Equals(_observacao)) return;
                _observacao = value;
                OnPropertyChanged(nameof(Observacao));
            }
        }
    }
}
