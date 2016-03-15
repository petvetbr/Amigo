using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class CaixaTransporte : EntidadeRepo, ICaixaTransporte
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

        DateTime? _DataCadastro;
        public DateTime? DataCadastro
        {
            get
            {
                return _DataCadastro;
            }
            set
            {
                if (_DataCadastro != value)
                {
                    _DataCadastro = value;
                    OnPropertyChanged(nameof(DataCadastro));
                }
            }
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}->{2}x{3}x{4}", this.Numero, this.Identificacao, this.Largura, this.Comprimento, this.Altura);
        }
        //public override bool Equals(object obj)
        //{
        //    var ob2 = obj as CaixaTransporte;
        //    if (ob2 == null) return false;
        //    return ob2._id== this._id;
        //}

    }
}
