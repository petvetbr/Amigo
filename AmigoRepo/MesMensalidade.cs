using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class MesMensalidade : EntidadeRepo, IMesMensalidade
    {
        int _ano;
        public int Ano
        {
            get
            {
                return _ano;
            }
            set
            {
                if (_ano != value)
                {
                    _ano = value;
                    OnPropertyChanged(nameof(Ano));
                }
            }
        }
        int _mes;
        public int Mes
        {
            get
            {
                return _mes;
            }
            set
            {
                if (_mes != value)
                {
                    _mes = value;
                    OnPropertyChanged(nameof(Mes));
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
        
    }
}
