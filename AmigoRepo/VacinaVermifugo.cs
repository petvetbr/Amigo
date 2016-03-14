using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class VacinaVermifugo : EntidadeRepo, IVacinaVermifugo
    {

        DateTime? _data;
        public DateTime? Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (object.Equals(_data, value)) return;
                _data = value;
                OnPropertyChanged(nameof(Data));

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
        public override string ToString()
        {
            return string.Format("{0:d}-{1}-{2}-{3}",_data, _Tipo, _Fabricante, Observacao);
        }

    }
}
