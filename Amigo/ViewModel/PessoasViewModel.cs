using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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

        ObservableCollection<IChaveValor<int,string>> _listaCategorias;
        public ObservableCollection<IChaveValor<int,string>> ListaCategorias
        {
            get
            {
                return _listaCategorias;
            }
            set
            {
                if (_listaCategorias != value)
                {
                    _listaCategorias = value;
                    RaisePropertyChanged(nameof(ListaCategorias));
                }
            }
        }
        ObservableCollection<IChaveValor<int, string>> _listaTipos;
        public ObservableCollection<IChaveValor<int, string>> ListaTipos
        {
            get
            {
                return _listaTipos;
            }
            set
            {
                if (_listaTipos != value)
                {
                    _listaTipos = value;
                    RaisePropertyChanged(nameof(ListaTipos));
                }
            }
        }
        ObservableCollection<IChaveValor<int,string>> _listaSatus;
        public ObservableCollection<IChaveValor<int, string>> ListaSatus
        {
            get
            {
                return _listaSatus;
            }
            set
            {
                if (_listaSatus != value)
                {
                    _listaSatus = value;
                    RaisePropertyChanged(nameof(ListaSatus));
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

            
            //var categorias = (ConfigurationManager.GetSection("appSettings/Categorias") as System.Collections.Hashtable)
            //     .Cast<System.Collections.DictionaryEntry>()
            //     .Select(n => new ChaveValor<int, string>() {
            //         Chave = Convert.ToInt32(n.Key),
            //         Valor = n.Value.ToString() });
                 
            //this.ListaCategorias = new ObservableCollection<IChaveValor<int, string>>(categorias);
            //var tipos = (ConfigurationManager.GetSection("Tipos") as System.Collections.Hashtable)
            //     .Cast<System.Collections.DictionaryEntry>()
            //      .Select(n => new ChaveValor<int, string>()
            //      {
            //          Chave = Convert.ToInt32(n.Key),
            //          Valor = n.Value.ToString()
            //      });
            //this.ListaSatus = new ObservableCollection<IChaveValor<int, string>>(tipos);

            //var status = (ConfigurationManager.GetSection("Status") as System.Collections.Hashtable)
            //     .Cast<System.Collections.DictionaryEntry>()
            //      .Select(n => new ChaveValor<int, string>()
            //      {
            //          Chave = Convert.ToInt32(n.Key),
            //          Valor = n.Value.ToString()
            //      });
            //this.ListaSatus = new ObservableCollection<IChaveValor<int, string>>(status);

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
