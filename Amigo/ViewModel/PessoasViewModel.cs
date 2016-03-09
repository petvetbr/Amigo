using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class PessoasViewModel: ViewModelBase
    {
        public RelayCommand SalvarCommand
        {
            get;
            private set;
        }
        
        //public RelayCommand AlteraCommand
        //{
        //    get;
        //    private set;
        //}
        public RelayCommand PesquisaCommand
        {
            get;
            private set;
        }
        public RelayCommand ExcluiCommand
        {
            get;
            private set;
        }

        IPessoa _pessoa;
        public IPessoa Pessoa
        {
            get
            {
                return _pessoa;
            }
            set
            {
                if (_pessoa != value)
                {
                    _pessoa = value;
                    RaisePropertyChanged(nameof(Pessoa));
                }
            }
        }
       
        public RelayCommand AlteraCommand { get; private set; }

        //bool podeAlterar = true;
        bool podeSalvar = true;
        bool podeExcluir = true;

        public PessoasViewModel()
        {
           
            Messenger.Default.Register<IPessoa>(this, PessoaEnviada);
            this.SalvarCommand = new RelayCommand(Salvar, () => podeSalvar);
            this.ExcluiCommand = new RelayCommand(Excluir, () => podeExcluir);
            this.PesquisaCommand = new RelayCommand(Pesquisar);
        }

        private void Salvar()
        {
            if(Util.Repositorio.Salvar<Socio>(this.Pessoa as Socio).Key)
            {
                Messenger.Default.Send(new CloseWindowMessage(), "PessoasWindow");
            }
            
        }

        private void Excluir()
        {
            Util.Repositorio.Apagar<Socio>(x=>x.Id== this.Pessoa.Id);
        }

        private void Pesquisar()
        {
            throw new NotImplementedException();
        }

        private void Alterar()
        {
            throw new NotImplementedException();
        }

        private void PessoaEnviada(IPessoa pessoa)
        {
            this.Pessoa = pessoa;
        }
    }
}
