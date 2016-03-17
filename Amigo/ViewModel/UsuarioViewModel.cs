using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class UsuarioViewModel:ViewModelBase
    {

        public RelayCommand SalvarCommand
        {
            get;
            private set;
        }

        public RelayCommand NovoItemCommand
        {
            get;
            private set;
        }

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

        ObservableCollection<KeyValuePair<int, string>> _listaCategorias;
        public ObservableCollection<KeyValuePair<int, string>> ListaCategorias
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
        Usuario _usuario;
        public Usuario Usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                    RaisePropertyChanged(nameof(Usuario));
                }
            }
        }

        bool expanderAberto;
        public bool ExpanderAberto
        {
            get
            {
                return expanderAberto;
            }
            set
            {
                if (expanderAberto != value)
                {
                    expanderAberto = value;
                    RaisePropertyChanged(nameof(ExpanderAberto));
                }
            }
        }
        ObservableCollection<Usuario> _listaItens;
        public ObservableCollection<Usuario> ListaItens
        {
            get
            {
                return _listaItens;
            }
            set
            {
                if (_listaItens != value)
                {
                    _listaItens = value;
                    RaisePropertyChanged(nameof(ListaItens));
                }
            }
        }

        string _filtroPesquisa;
        public string FiltroPesquisa
        {
            get
            {
                return _filtroPesquisa;
            }
            set
            {
                if (_filtroPesquisa != value)
                {
                    _filtroPesquisa = value;
                    RaisePropertyChanged(nameof(FiltroPesquisa));
                }
            }
        }

        SecureString _senha;
        public SecureString Senha
        {
            get
            {
                return _senha;
            }
            set
            {
                if (_senha != value)
                {
                    _senha = value;
                    RaisePropertyChanged(nameof(Senha));
                }
            }
        }
        public UsuarioViewModel()
        {

        }

        private void CriarNovoItem()
        {


            var Usuario = new Usuario();
            if (Util.Repositorio.ObterLista<Usuario>().Any())
            {
                var maxAtual = Util.Repositorio.ObterLista<Usuario>().Max(p => p.Numero);
                Usuario.Numero = ++maxAtual;
            }
            else
            {
                Usuario.Numero = 1;
            }
            this.Usuario = Usuario;
            ExpanderAberto = false;
        }



        private void Excluir()
        {
            if (!Util.Repositorio.Apagar<Usuario>(x => x.Id == this.Usuario.Id))
            {
                return;
            }
            this.Usuario = null;
            RefreshLista();
            ExpanderAberto = true;
        }

        private void Salvar()
        {
            if (!Util.Repositorio.Salvar<Usuario>(_usuario).Key)
            {
                return;
            }
            RefreshLista();
            ExpanderAberto = true;
        }

        private void Pesquisar()
        {
            if (string.IsNullOrWhiteSpace(FiltroPesquisa))
            {
                RefreshLista();
                return;
            }
            RefreshLista(x => x.Nome.Contains(FiltroPesquisa));
        }


        private void RefreshLista(Expression<Func<Usuario, bool>> expression = null)
        {
            var lista = Util.Repositorio.ObterLista<Usuario>(expression).OrderBy(p => p.Nome);
            this.ListaItens = new ObservableCollection<Usuario>(lista);
        }
    }
}
