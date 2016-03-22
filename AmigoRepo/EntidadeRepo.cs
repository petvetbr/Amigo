using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public abstract class EntidadeRepo : Observable, IRepositorio
    {
        string _repositorio;
        public string Repositorio
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
        protected int _numero;
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

        protected int _id;
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (value.Equals(_id)) return;
                _id = value;
                OnPropertyChanged(nameof(Id));
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
