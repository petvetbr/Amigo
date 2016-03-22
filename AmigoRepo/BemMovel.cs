using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoRepo
{
    public class BemMovel:EntidadeRepo, IObservacao
    {
        DateTime _dataCadastro;
        public DateTime DataCadastro
        {
            get
            {
                return _dataCadastro;
            }
            set
            {
                if (_dataCadastro != value)
                {
                    _dataCadastro = value;
                    OnPropertyChanged(nameof(DataCadastro));
                }
            }
        }


        string _descricao;
        public string Descricao
        {
            get
            {
                return _descricao;
            }
            set
            {
                if (_descricao != value)
                {
                    _descricao = value;
                    OnPropertyChanged(nameof(Descricao));
                }
            }
        }

        int _tipoBem;
        public int TipoBem
        {
            get
            {
                return _tipoBem;
            }
            set
            {
                if (_tipoBem != value)
                {
                    _tipoBem = value;
                    OnPropertyChanged(nameof(TipoBem));
                }
            }
        }
        int _origem;
        public int Origem
        {
            get
            {
                return _origem;
            }
            set
            {
                if (_origem != value)
                {
                    _origem = value;
                    OnPropertyChanged(nameof(Origem));
                }
            }
        }
        string _nomeProprietario;
        public string NomeProprietario
        {
            get
            {
                return _nomeProprietario;
            }
            set
            {
                if (_nomeProprietario != value)
                {
                    _nomeProprietario = value;
                    OnPropertyChanged(nameof(NomeProprietario));
                }
            }
        }


        string _nomeResponsavelEmprestimo;
        public string NomeResponsavelEmprestimo
        {
            get
            {
                return _nomeResponsavelEmprestimo;
            }
            set
            {
                if (_nomeResponsavelEmprestimo != value)
                {
                    _nomeResponsavelEmprestimo = value;
                    OnPropertyChanged(nameof(NomeResponsavelEmprestimo));
                }
            }
        }
        string _nomeNomePegadorEmprestimo;
        public string NomeNomePegadorEmprestimo
        {
            get
            {
                return _nomeNomePegadorEmprestimo;
            }
            set
            {
                if (_nomeNomePegadorEmprestimo != value)
                {
                    _nomeNomePegadorEmprestimo = value;
                    OnPropertyChanged(nameof(NomeNomePegadorEmprestimo));
                }
            }
        }
        DateTime? _dataSaida;
        public DateTime? DataSaida
        {
            get
            {
                return _dataSaida;
            }
            set
            {
                if (_dataSaida != value)
                {
                    _dataSaida = value;
                    OnPropertyChanged(nameof(DataSaida));
                }
            }
        }
        DateTime? _dataRetorno;
        public DateTime? DataRetorno
        {
            get
            {
                return _dataRetorno;
            }
            set
            {
                if (_dataRetorno != value)
                {
                    _dataRetorno = value;
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

        int _localizacao;
        public int Localizacao
        {
            get
            {
                return _localizacao;
            }
            set
            {
                if (_localizacao == value)
                {
                    return;
                }
                _localizacao = value;
                OnPropertyChanged(nameof(Localizacao));
            }
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}",_numero, _descricao);
        }
    }
}
