using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class Animal : EntidadeRepo, IAnimal
    {
        IChaveValor<int, string> _ambiente;
        public IChaveValor<int, string> Ambiente
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
        IVeterinario _clinica;
        public IVeterinario Clinica
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

        DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get
            {
                return _dataNascimento;
            }

            set
            {
                if (value.Equals(_dataNascimento)) return;
                _dataNascimento = value;
                OnPropertyChanged(nameof(DataNascimento));
            }
        }

        private IChaveValor<int, string> _especie;
        public IChaveValor<int, string> Especie
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

       

        int _peso;
        public int Peso
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

        IChaveValor<int, string> _raca;
        public IChaveValor<int, string> Raca
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
       

        IChaveValor<int, string> _sexo;
        public IChaveValor<int, string> Sexo
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

        IChaveValor<int, string> _status;
        public IChaveValor<int, string> Status
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

        IPessoa _tutor;
        public IPessoa Tutor
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
        IEnumerable<IChaveValor<DateTime, IVacinaVermifugo>> _vacinas;
        public IEnumerable<IChaveValor<DateTime, IVacinaVermifugo>> Vacinas
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
        IEnumerable<IChaveValor<DateTime, IVacinaVermifugo>> _vermifugos;
        public IEnumerable<IChaveValor<DateTime, IVacinaVermifugo>> Vermifugos
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
    }
}
