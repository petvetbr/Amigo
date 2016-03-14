using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class AnimalViewModel:ViewModelBase
    {
        #region Commands
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
        public RelayCommand NovaVacinaCommand
        {
            get;
            private set;
        }
        public RelayCommand ExcluiVacinaCommand
        {
            get;
            private set;
        }
        public RelayCommand NovaVermifugoCommand
        {
            get;
            private set;
        }
        public RelayCommand ExcluiVermifugoCommand
        {
            get;
            private set;
        }

        #endregion
        #region Propriedades
        Animal _animal;
        public Animal Animal
        {
            get
            {
                return _animal;
            }
            set
            {
                if (_animal != value)
                {
                    _animal = value;
                    RaisePropertyChanged(nameof(Animal));
                }
            }
        }
        ObservableCollection<IAnimal> _listaItens;
        public ObservableCollection<IAnimal> ListaItens
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

        ObservableCollection<KeyValuePair<int, string>> _listaSexo;
        public ObservableCollection<KeyValuePair<int, string>> ListaSexo
        {
            get
            {
                return _listaSexo;
            }
            set
            {
                if (_listaSexo != value)
                {
                    _listaSexo = value;
                    RaisePropertyChanged(nameof(ListaSexo));
                }
            }
        }

        ObservableCollection<KeyValuePair<int, string>> _listaRaca;
        public ObservableCollection<KeyValuePair<int, string>> ListaRaca
        {
            get
            {
                return _listaRaca;
            }
            set
            {
                if (_listaRaca != value)
                {
                    _listaRaca = value;
                    RaisePropertyChanged(nameof(ListaRaca));
                }
            }
        }

        ObservableCollection<KeyValuePair<int, string>> _listaAmbiente;
        public ObservableCollection<KeyValuePair<int, string>> ListaAmbiente
        {
            get
            {
                return _listaAmbiente;
            }
            set
            {
                if (_listaAmbiente != value)
                {
                    _listaAmbiente = value;
                    RaisePropertyChanged(nameof(ListaAmbiente));
                }
            }
        }

        public ObservableCollection<IVacinaVermifugo> _listaTipoVacina;
        public ObservableCollection<IVacinaVermifugo> ListaTipoVacina
        {
            get
            {
                return _listaTipoVacina;
            }
            set
            {
                if (_listaTipoVacina != value)
                {
                    _listaTipoVacina = value;
                    RaisePropertyChanged(nameof(ListaTipoVacina));
                }
            }
        }

        public ObservableCollection<IVacinaVermifugo> _listaTipoVermifugo;
        public ObservableCollection<IVacinaVermifugo> ListaTipoVermifugo
        {
            get
            {
                return _listaTipoVermifugo;
            }
            set
            {
                if (_listaTipoVermifugo != value)
                {
                    _listaTipoVermifugo = value;
                    RaisePropertyChanged(nameof(ListaTipoVermifugo));
                }
            }
        } 
        #endregion
        public AnimalViewModel()
        {
          
            this.SalvarCommand = new RelayCommand(Salvar, () => Animal != null);
            this.ExcluiCommand = new RelayCommand(Excluir, () => Animal != null);
            this.PesquisaCommand = new RelayCommand(Pesquisar);
            this.NovoItemCommand = new RelayCommand(CriarNovoItem);
            this.ListaSexo = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaGeneroAnimal());
            this.ListaAmbiente = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaAmbientesAnimal());
            this.NovaVacinaCommand = new RelayCommand(NovaVacina);
            this.ExcluiVacinaCommand = new RelayCommand(ExcluiVacina);
            this.NovaVermifugoCommand = new RelayCommand(NovoVermifugo);
            this.ExcluiVermifugoCommand = new RelayCommand(ExcluiVermifugo);

            RefreshLista();
            ExpanderAberto = true;

        }

        private void ExcluiVermifugo()
        {
            throw new NotImplementedException();
        }

        private void NovoVermifugo()
        {
            throw new NotImplementedException();
        }

        private void NovaVacina()
        {
            throw new NotImplementedException();
        }

        private void ExcluiVacina()
        {
            throw new NotImplementedException();
        }

        private void RefreshLista(Expression<Func<Animal, bool>> expression = null)
        {
            var lista = Util.Repositorio.ObterLista<Animal>(expression).OrderBy(p => p.Nome);
            this.ListaItens = new ObservableCollection<IAnimal>(lista);
        }

        private void CriarNovoItem()
        {
            var animal = new Animal() { DataCadastro = DateTime.Now };
            if (Util.Repositorio.ObterLista<CaixaTransporte>().Any())
            {
                var maxAtual = Util.Repositorio.ObterLista<CaixaTransporte>().Max(p => p.Numero);
                animal.Numero = ++maxAtual;
            }
            else
            {
                animal.Numero = 1;
            }
            this.Animal = animal;
            ExpanderAberto = false;
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

        private void Excluir()
        {
            if (!Util.Repositorio.Apagar<Animal>(x => x.Id == this.Animal.Id))
            {
                return;
            }
            this.Animal = null;
            RefreshLista();
            ExpanderAberto = true;
        }

        private void Salvar()
        {
            if (!Util.Repositorio.Salvar<Animal>(_animal).Key)
            {
                return;
            }
            RefreshLista();
            ExpanderAberto = true;
        }
    }

}

