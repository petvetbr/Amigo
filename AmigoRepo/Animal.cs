using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class Animal : EntidadeRepo, IAnimal
    {
        int _ambiente;
        public int Ambiente
        {
            get
            {
                return _ambiente;
            }

            set
            {
                if (value.Equals(_ambiente)) return;
                _ambiente = value;
                OnPropertyChanged(nameof(Ambiente));
            }
        }

        bool _castrado;
        public bool Castrado
        {
            get
            {
                return _castrado;
            }

            set
            {
                if (value.Equals(_castrado)) return;
                _castrado = value;
                OnPropertyChanged(nameof(Castrado));
            }
        }
        Pessoa _clinica;
        public Pessoa Clinica
        {
            get
            {
                return _clinica;
            }

            set
            {
                if (value.Equals(_clinica)) return;
                _clinica = value;
                OnPropertyChanged(nameof(Clinica));
            }
        }

        DateTime? _DataCadastro;
        public DateTime? DataCadastro
        {
            get
            {
                return _DataCadastro;
            }

            set
            {
                if (value.Equals(_DataCadastro)) return;
                _DataCadastro = value;
                OnPropertyChanged(nameof(DataCadastro));
            }
        }
        DateTime? _DataNascimento;
        public DateTime? DataNascimento
        {
            get
            {
                return _DataNascimento;
            }

            set
            {

                if (!object.Equals(value,_DataNascimento))
                {
                    _DataNascimento = value;
                    OnPropertyChanged(nameof(DataNascimento));
                }
                OnPropertyChanged(nameof(Idade));

            }
        }

        private int _especie;
        public int Especie
        {
            get
            {
                return _especie;
            }

            set
            {
                if (value.Equals(_especie)) return;
                _especie = value;
                OnPropertyChanged(nameof(Especie));
            }
        }

        string _nome;
        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                if (value.Equals(_nome)) return;
                _nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }



        float _peso;
        public float Peso
        {
            get
            {
                return _peso;
            }

            set
            {
                if (value.Equals(_peso)) return;
                _peso = value;
                OnPropertyChanged(nameof(Peso));
            }
        }

        string _raca;
        public string Raca
        {
            get
            {
                return _raca;
            }

            set
            {
                if (value.Equals(_raca)) return;
                _raca = value;
                OnPropertyChanged(nameof(Raca));
            }
        }


        int _sexo;
        public int Sexo
        {
            get
            {
                return _sexo;
            }

            set
            {
                if (value.Equals(_sexo)) return;
                _sexo = value;
                OnPropertyChanged(nameof(Sexo));
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
                if (value.Equals(_status)) return;
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        string _tutor;
        public string Tutor
        {
            get
            {
                return _tutor;
            }

            set
            {
                if (value.Equals(_tutor)) return;
                _tutor = value;
                OnPropertyChanged(nameof(Tutor));
            }
        }
        ObservableCollection<IVacinaVermifugo> _vacinas;
        public ObservableCollection<IVacinaVermifugo> Vacinas
        {
            get
            {
                return _vacinas;
            }

            set
            {
                if (value.Equals(_vacinas)) return;
                _vacinas = value;
                OnPropertyChanged(nameof(Vacinas));
            }
        }
        ObservableCollection<IVacinaVermifugo> _vermifugos;
        public ObservableCollection<IVacinaVermifugo> Vermifugos
        {
            get
            {
                return _vermifugos;
            }

            set
            {
                if (value.Equals(_vermifugos)) return;
                _vermifugos = value;
                OnPropertyChanged(nameof(Vermifugos));
            }
        }
        string _foto;
        public string Foto
        {
            get
            {
                return _foto;
            }
            set
            {
                if (_foto != value)
                {
                    _foto = value;
                    OnPropertyChanged(nameof(Foto));
                }
            }
        }

        public string Idade
        {
            get
            {
                return ObterIdade();
            }

        }


        public Animal()
        {
            this.Vacinas = new ObservableCollection<IVacinaVermifugo>();
            this.Vermifugos = new ObservableCollection<IVacinaVermifugo>();
        }
        public override string ToString()
        {
            string idade = ObterIdade();
            return string.Format("{0}-{1}-{2}-{3}", _nome, _raca, _tutor, idade);
        }

        private string ObterIdade()
        {
            string idade = string.Empty;
            if (_DataNascimento != null)

            {
                var timespanIdade = DateTime.Now - _DataNascimento.Value;
                idade = new DateDifference(DateTime.Now, _DataNascimento.Value).ToString();

            }

            return idade;
        }
    }
}
