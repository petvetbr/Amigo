using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using AmigoRepo;
using GalaSoft.MvvmLight.Command;

namespace Amigo.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public RelayCommand AbrirItem
        {
            get;
            private set;
        }

        ObservableCollection<KeyValuePair<int, string>> _listaCombo;
        public ObservableCollection<KeyValuePair<int, string>> ListaCombo
        {
            get
            {
                return _listaCombo;
            }
            set
            {
                if (_listaCombo != value)
                {
                    _listaCombo = value;
                    RaisePropertyChanged(nameof(ListaCombo));
                }
            }
        }

        ObservableCollection<IRepositorio> _listaItens;
        public ObservableCollection<IRepositorio> ListaItens
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



        KeyValuePair<int, string> itemSelecionado;
        public KeyValuePair<int, string> ItemSelecionado
        {
            get
            {
                return itemSelecionado;
            }
            set
            {
                if (!itemSelecionado.Equals(value))
                {
                    itemSelecionado = value;
                    RaisePropertyChanged(nameof(ItemSelecionado));
                    if (value.Key > 0) { AlterarLista(); }
                }
            }
        }
        IRepositorio itemSelecionadoLista;
        public IRepositorio ItemSelecionadoLista
        {
            get
            {
                return itemSelecionadoLista;
            }
            set
            {
                if (!object.Equals(value, itemSelecionadoLista))
                {
                    itemSelecionadoLista = value;
                    RaisePropertyChanged(nameof(ItemSelecionadoLista));
                }
            }
        }

        private void AlterarLista()
        {
            switch (itemSelecionado.Key)
            {
                case 1:
                    {
                        using (var repo = new Repositorio("Teste"))
                        {
                            var lista = repo.ObterLista<Socio>(null);
                            this.ListaItens = new ObservableCollection<IRepositorio>(lista);
                        }
                    }
                    break;
                case 2:
                    {
                        using (var repo = new Repositorio("Teste"))
                        {
                            var lista = repo.ObterLista<CaixaTransporte>(p => true);
                            this.ListaItens = new ObservableCollection<IRepositorio>(lista);
                        }
                    }
                    break;
                case 3:
                    {

                    }
                    break;
                default:
                    break;
            }
        }



        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            var listaCombo = new Dictionary<int, string>();
            listaCombo.Add(1, "Sócios");
            listaCombo.Add(2, "Caixas Transporte");
            listaCombo.Add(3, "Mensalidades");
            this.ListaCombo = new ObservableCollection<KeyValuePair<int, string>>(listaCombo);

            AbrirItem = new RelayCommand(ExecutarAbrirItem,() => itemSelecionadoLista != null);
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private void ExecutarAbrirItem()
        {
            throw new NotImplementedException();
        }
    }
}