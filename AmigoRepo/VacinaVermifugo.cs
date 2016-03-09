using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class VacinaVermifugo: EntidadeRepo,IVacinaVermifugo
    {
        string _Descricao;
        public string Descricao
        {
            get
            {
                return _Descricao;
            }
            set
            {
                if (value.Equals(_Descricao)) return;
                _Descricao = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }
        string _Fabricante;
        public string Fabricante
        {
            get
            {
                return _Fabricante;
            }
            set
            {
                if (value.Equals(_Fabricante)) return;
                _Fabricante = value;
                OnPropertyChanged(nameof(Fabricante));
            }
        }
        string _Lote;
        public string Lote
        {
            get
            {
                return _Lote;
            }
            set
            {
                if (value.Equals(_Lote)) return;
                _Lote = value;
                OnPropertyChanged(nameof(Lote));
            }
        }
        string _Tipo;
        public string Tipo
        {
            get
            {
                return _Tipo;
            }
            set
            {
                if (value.Equals(_Tipo)) return;
                _Tipo = value;
                OnPropertyChanged(nameof(Tipo));
            }
        }
    }
}
