using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoRepo
{
    public class Agendamento:EntidadeRepo,IObservacao
    {
        string _nomePessoa;
        public string NomePessoa
        {
            get
            {
                return _nomePessoa;
            }
            set
            {
                if (_nomePessoa != value)
                {
                    _nomePessoa = value;
                    OnPropertyChanged(nameof(NomePessoa));
                }
            }
        }
        string _nomeAnimal;
        public string NomeAnimal
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
                    OnPropertyChanged(nameof(NomeAnimal));
                }
            }
        }

        DateTime? _dataAgenda;
        public DateTime? DataAgenda
        {
            get
            {
                return _dataAgenda;
            }
            set
            {
                if (_dataAgenda != value)
                {
                    _dataAgenda = value;
                    OnPropertyChanged(nameof(DataAgenda));
                }
            }
        }
        int _codigoExecucao;
        public int CodigoExecucao
        {
            get
            {
                return _codigoExecucao;
            }
            set
            {
                if (_codigoExecucao != value)
                {
                    _codigoExecucao = value;
                    OnPropertyChanged(nameof(CodigoExecucao));
                }
            }
        }
        int idVetOuClinica;
        public int IdVetOuClinica
        {
            get
            {
                return idVetOuClinica;
            }
            set
            {
                if (idVetOuClinica != value)
                {
                    idVetOuClinica = value;
                    OnPropertyChanged(nameof(IdVetOuClinica));
                }
            }
        }

        int _codigoStatus;
        public int CodigoStatus
        {
            get
            {
                return _codigoStatus;
            }
            set
            {
                if (_codigoStatus != value)
                {
                    _codigoStatus = value;
                    OnPropertyChanged(nameof(CodigoStatus));
                }
            }
        }
    }
}
