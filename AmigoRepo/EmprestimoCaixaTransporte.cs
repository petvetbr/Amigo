using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoRepo
{
    public class EmprestimoCaixaTransporte:EntidadeRepo, IEmprestimoCaixa
    {
        string _nomeTutor;
        public string Responsavel
        {
            get
            {
                return _nomeTutor;
            }
            set
            {
                if (_nomeTutor != value)
                {
                    _nomeTutor = value;
                    OnPropertyChanged(nameof(Responsavel));
                }
            }
        }
        string _nomeAnimal;
        public string Animal
        {
            get
            {
                return _nomeAnimal;
            }
            set
            {
                if (_nomeAnimal != value)
                {
                    _nomeAnimal = value;
                    OnPropertyChanged(nameof(Animal));
                }
            }
        }
        DateTime? _DataSaida;
        public DateTime? DataSaida
        {
            get
            {
                return _DataSaida;
            }
            set
            {
                if (_DataSaida != value)
                {
                    _DataSaida = value;
                    OnPropertyChanged(nameof(DataSaida));
                }
            }
        }
        DateTime? _DataRetorno;
        public DateTime? DataRetorno
        {
            get
            {
                return _DataRetorno;
            }
            set
            {
                if (_DataRetorno != value)
                {
                    _DataRetorno = value;
                    OnPropertyChanged(nameof(DataRetorno));
                }
            }
        }
        int _status;
        public int Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }
        int _situacao;
        public int Situacao
        {
            get
            {
                return _situacao;
            }
            set
            {
                if (_situacao != value)
                {
                    _situacao = value;
                    OnPropertyChanged(nameof(Situacao));
                }
            }
        }
     

        CaixaTransporte _caixaTransporte;
        public CaixaTransporte CaixaTransporte
        {
            get
            {
                return _caixaTransporte;
            }
            set
            {
                if (_caixaTransporte != value)
                {
                    _caixaTransporte = value;
                    OnPropertyChanged(nameof(CaixaTransporte));
                }
            }
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2:d}-{3:d}", CaixaTransporte.Numero, Responsavel, DataSaida, DataRetorno);
        }
      
    }
}
