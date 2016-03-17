using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmigoRepo
{
    public class Usuario : EntidadeRepo, IRepositorio
    {
        string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged(nameof(Login));
                }
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
                if (_nome != value)
                {
                    _nome = value;
                    OnPropertyChanged(nameof(Nome));
                }
            }
        }
       


        string _stringHash;
        public string StringHash
        {
            get
            {
                return _stringHash;
            }
            set
            {
                if (_stringHash != value)
                {
                    _stringHash = value;
                    OnPropertyChanged(nameof(StringHash));
                }
            }
        }
        int _nivel;
        public int Nivel
        {
            get
            {
                return _nivel;
            }
            set
            {
                if (_nivel != value)
                {
                    _nivel = value;
                    OnPropertyChanged(nameof(Nivel));
                }
            }
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}", _nome, _login);
        }
    }
}
