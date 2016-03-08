using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class EmprestimoCaixa : EntidadeRepo, IEmprestimoCaixa
    {
        IAnimal _Animal;
        public IAnimal Animal
        {
            get
            {
                return _Animal;
            }

            set
            {
                if (value.Equals(_Animal)) return;
                _Animal = value;
                OnPropertyChanged(nameof(Animal));
            }
        }

        DateTime _DataRetorno;
        public DateTime DataRetorno
        {
            get
            {
                return _DataRetorno;
            }

            set
            {
                if (value.Equals(_DataRetorno)) return;
                _DataRetorno = value;
                OnPropertyChanged(nameof(DataRetorno));
            }
        }

        DateTime _DataSaida;
        public DateTime DataSaida
        {
            get
            {
                return _DataSaida;
            }

            set
            {
                if (value.Equals(_DataSaida)) return;
                _DataSaida = value;
                OnPropertyChanged(nameof(DataSaida));
            }
        }

        IPessoa _Responsavel;
        public IPessoa Responsavel
        {
            get
            {
                return _Responsavel;

            }

            set
            {
                if (value.Equals(_Responsavel)) return;
                _Responsavel = value;
                OnPropertyChanged(nameof(Responsavel));
            }
        }

        IChaveValor<int, string> _Situacao;
        public IChaveValor<int, string> Situacao
        {
            get
            {
                return _Situacao;
            }

            set
            {
                if (value.Equals(_Situacao)) return;
                _Situacao = value;
                OnPropertyChanged(nameof(Situacao));
            }
        }

        IChaveValor<int, string> _Status;
        public IChaveValor<int, string> Status
        {
            get
            {
                return _Status;
            }

            set
            {
                if (value.Equals(_Status)) return;
                _Status = value;
                OnPropertyChanged(nameof(_Status));
            }
        }
    }
}
