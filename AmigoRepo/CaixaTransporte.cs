using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    class CaixaTransporte:EntidadeRepo, ICaixaTransporte
    {
        int _altura;
        public int Altura
        {
            get
            {
                return _altura;
            }
            set
            {
                if (_altura != value)
                {
                    _altura = value;
                    OnPropertyChanged(nameof(Altura));
                }
            }
        }
        int _largura;
        public int Largura
        {
            get
            {
                return _largura;
            }
            set
            {
                if (_largura != value)
                {
                    _largura = value;
                    OnPropertyChanged(nameof(Largura));
                }
            }
        }

        int _comprimento;
        public int Comprimento
        {
            get
            {
                return _comprimento;
            }
            set
            {
                if (_comprimento != value)
                {
                    _comprimento = value;
                    OnPropertyChanged(nameof(Comprimento));
                }
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
                if (_peso != value)
                {
                    _peso = value;
                    OnPropertyChanged(nameof(Peso));
                }
            }
        }

        string _identificacao;
        public string Identificacao
        {
            get
            {
                return _identificacao;
            }
            set
            {
                if (_identificacao != value)
                {
                    _identificacao = value;
                    OnPropertyChanged(nameof(Identificacao));
                }
            }
        }

        IChaveValor<int,string> _localizacao;
        public IChaveValor<int, string> Localizacao
        {
            get
            {
                return _localizacao;
            }
            set
            {
                if (_localizacao != value)
                {
                    _localizacao = value;
                    OnPropertyChanged(nameof(Localizacao));
                }
            }
        }

      
    }
}
