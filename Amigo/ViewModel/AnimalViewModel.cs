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

        ObservableCollection<KeyValuePair<int, string>> _listaEspecie;
        public ObservableCollection<KeyValuePair<int, string>> ListaEspecie
        {
            get
            {
                return _listaEspecie;
            }
            set
            {
                if (_listaEspecie != value)
                {
                    _listaEspecie = value;
                    RaisePropertyChanged(nameof(ListaEspecie));
                }
            }
        }

        ObservableCollection<string> _listaRaca;
        public ObservableCollection<string> ListaRaca
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

        public ObservableCollection<string> _listaTipoVacina;
        public ObservableCollection<string> ListaTipoVacina
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
        public ObservableCollection<string> _listaFabricanteVermifugo;
        public ObservableCollection<string> ListaFabricanteVermifugo
        {
            get
            {
                return _listaFabricanteVermifugo;
            }
            set
            {
                if (_listaFabricanteVermifugo != value)
                {
                    _listaFabricanteVermifugo = value;
                    RaisePropertyChanged(nameof(ListaFabricanteVermifugo));
                }
            }
        }
        IVacinaVermifugo _vacinaSelecionada;
        public IVacinaVermifugo VacinaSelecionada
        {
            get
            {
                return _vacinaSelecionada;
            }
            set
            {
                if (_vacinaSelecionada != value)
                {
                    _vacinaSelecionada = value;
                    RaisePropertyChanged(nameof(VacinaSelecionada));
                }
            }
        }
        IVacinaVermifugo _vermifugoSelecionado;
        public IVacinaVermifugo VermifugoSelecionado
        {
            get
            {
                return _vermifugoSelecionado;
            }
            set
            {
                if (_vermifugoSelecionado != value)
                {
                    _vermifugoSelecionado = value;
                    RaisePropertyChanged(nameof(VermifugoSelecionado));
                }
            }
        }

        public ObservableCollection<string> _listaFabricanteVacina;
        public ObservableCollection<string> ListaFabricanteVacina
        {
            get
            {
                return _listaFabricanteVacina;
            }
            set
            {
                if (_listaFabricanteVacina != value)
                {
                    _listaFabricanteVacina = value;
                    RaisePropertyChanged(nameof(ListaFabricanteVacina));
                }
            }
        }
        ObservableCollection<IPessoa> _listaveterinario;
        public ObservableCollection<IPessoa> ListaVeterinarios
        {
            get
            {
                return _listaveterinario;
            }
            set
            {
                if (_listaveterinario != value)
                {
                    _listaveterinario = value;
                    RaisePropertyChanged(nameof(ListaVeterinarios));
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
            CarregarListas();
            this.ListaEspecie = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaEspecieAnimal());
            this.NovaVacinaCommand = new RelayCommand(NovaVacina);
            this.ExcluiVacinaCommand = new RelayCommand(ExcluiVacina);
            this.NovaVermifugoCommand = new RelayCommand(NovoVermifugo);
            this.ExcluiVermifugoCommand = new RelayCommand(ExcluiVermifugo);
            this.VacinaSelecionada = new VacinaVermifugo();
            this.VermifugoSelecionado = new VacinaVermifugo();

            RefreshLista();
            ExpanderAberto = true;

        }

        private void CarregarListas()
        {
            this.ListaSexo = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaGeneroAnimal());
            this.ListaAmbiente = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaAmbientesAnimal());
            this.ListaFabricanteVacina = new ObservableCollection<string>(Config.ObterListaFabricantesVacina());
            this.ListaFabricanteVermifugo = new ObservableCollection<string>(Config.ObterListaFabricantesVermifugo());
            this.ListaTipoVacina = new ObservableCollection<string>(Config.ObterListaTiposVacina());
            this.ListaRaca = new ObservableCollection<string>(Config.ObterRacasCaes());
            this.ListaVeterinarios = new ObservableCollection<IPessoa>(Util.Repositorio.ObterLista<Pessoa>(null, "Veterinarios"));
        }

        private void ExcluiVermifugo()
        {
            this.Animal.Vermifugos.Remove(_vermifugoSelecionado);
            this.VermifugoSelecionado = null;
        }

        private void NovoVermifugo()
        {
            this.Animal.Vermifugos.Add(_vermifugoSelecionado);
            this.VermifugoSelecionado = null;

        }

        private void NovaVacina()
        {
            this.Animal.Vacinas.Add(_vacinaSelecionada);
            this.VacinaSelecionada = null;
        }

        private void ExcluiVacina()
        {
            this.Animal.Vacinas.Remove(_vacinaSelecionada);
            this.VacinaSelecionada = null;
        }

        private void RefreshLista(Expression<Func<Animal, bool>> expression = null)
        {
            var lista = Util.Repositorio.ObterLista<Animal>(expression).OrderBy(p => p.Nome);
            this.ListaItens = new ObservableCollection<IAnimal>(lista);
        }

        private void CriarNovoItem()
        {
            var animal = new Animal() { DataCadastro = DateTime.Now };
            if (Util.Repositorio.ObterLista<Animal>().Any())
            {
                var maxAtual = Util.Repositorio.ObterLista<Animal>().Max(p => p.Numero);
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

