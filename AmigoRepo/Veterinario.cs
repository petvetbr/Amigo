using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
   public class Veterinario : EntidadeRepo, IVeterinario
    {
       int _Crmv;
        public int Crmv
        {
            get
            {
                return _Crmv;
            }
            set
            {
                if (value.Equals(_Crmv)) return;
                _Crmv = value;
                OnPropertyChanged(nameof(Crmv));
            }
        }
        string _Uf;
        public string Uf
        {
            get
            {
                return _Uf;
            }
            set
            {
                if (value.Equals(_Uf)) return;
                _Uf = value;
                OnPropertyChanged(nameof(Uf));
            }
        }
        DateTime _DataCadastro;
        public DateTime DataCadastro
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
        DateTime _DataNascimento;
        public DateTime DataNascimento
        {
            get
            {
                return _DataNascimento;
            }
            set
            {
                if (value.Equals(_DataNascimento)) return;
                _DataNascimento = value;
                OnPropertyChanged(nameof(DataNascimento));
            }
        }
        string _Cidade;
        public string Cidade
        {
            get
            {
                return _Cidade;
            }
            set
            {
                if (value.Equals(_Cidade)) return;
                _Cidade = value;
                OnPropertyChanged(nameof(Cidade));
            }
        }

        string _CEP;
        public string CEP
        {
            get
            {
                return _CEP;
            }
            set
            {
                if (value.Equals(_CEP)) return;
                _CEP = value;
                OnPropertyChanged(nameof(CEP));
            }
        }
        string _Endereco;
        public string Endereco
        {
            get
            {
                return _Endereco;
            }
            set
            {
                if (value.Equals(_Endereco)) return;
                _Endereco = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
        string _Nome;
        public string Nome
        {
            get
            {
                return _Nome;
            }
            set
            {
                if (value.Equals(_Nome)) return;
                _Nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }
        string _NomeFantasia;
        public string NomeFantasia
        {
            get
            {
                return _NomeFantasia;
            }
            set
            {
                if (value.Equals(_NomeFantasia)) return;
                _NomeFantasia = value;
                OnPropertyChanged(nameof(NomeFantasia));
            }
        }
        string _NomeRepresentante;
        public string NomeRepresentante
        {
            get
            {
                return _NomeRepresentante;
            }
            set
            {
                if (value.Equals(_NomeRepresentante)) return;
                _NomeRepresentante = value;
                OnPropertyChanged(nameof(NomeRepresentante));
            }
        }
        string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (value.Equals(_Email)) return;
                _Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        string _Cpf_Cnpj;
        public string Cpf_Cnpj
        {
            get
            {
                return _Cpf_Cnpj;
            }
            set
            {
                if (value.Equals(_Cpf_Cnpj)) return;
                _Cpf_Cnpj = value;
                OnPropertyChanged(nameof(Cpf_Cnpj));
            }
        }
        string _TipoPessoa;
        public string TipoPessoa
        {
            get
            {
                return _TipoPessoa;
            }
            set
            {
                if (value.Equals(_TipoPessoa)) return;
                _TipoPessoa = value;
                OnPropertyChanged(nameof(TipoPessoa));
            }
        }
        string _Homepage;
        public string Homepage
        {
            get
            {
                return _Homepage;
            }
            set
            {
                if (value.Equals(_Homepage)) return;
                _Homepage = value;
                OnPropertyChanged(nameof(Homepage));
            }
        }
        IEnumerable<ITelefone> _Telefones;
        public IEnumerable<ITelefone> Telefones
        {
            get
            {
                return _Telefones;
            }
            set
            {
                if (value.Equals(_Telefones)) return;
                _Telefones = value;
                OnPropertyChanged(nameof(Telefones));
            }
        }
        IChaveValor<int, string> _Status;
        public IChaveValor<int, string> Status
        {
            get
            {
                return _Status;
            }
            set
            {
                if (value.Equals(_Status)) return;
                _Status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        string _UF;
        public string UF
        {
            get
            {
                return _UF;
            }

            set
            {
                if (value.Equals(_UF)) return;
                _UF = value;
                OnPropertyChanged(nameof(UF));
            }
        }
    }
}
