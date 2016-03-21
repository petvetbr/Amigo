using AmigoRepo;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class AniversariantesViewModel:ViewModelBase
    {
        ObservableCollection<KeyValuePair<int,string>> _listaMeses;
        public ObservableCollection<KeyValuePair<int,string>> ListaMeses
        {
            get
            {
                return _listaMeses;
            }
            set
            {
                if (_listaMeses != value)
                {
                    _listaMeses = value;
                    RaisePropertyChanged(nameof(ListaMeses));
                }
            }
        }

        int _mesSelecionado;
        public int MesSelecionado
        {
            get
            {
                return _mesSelecionado;
            }
            set
            {
                if (_mesSelecionado != value)
                {
                    _mesSelecionado = value;
                    RaisePropertyChanged(nameof(MesSelecionado));
                    FiltrarAniversariantes(value);
                }
            }
        }
        ObservableCollection<KeyValuePair<Pessoa, string>> _listaAniversariantes;
        public ObservableCollection<KeyValuePair<Pessoa, string>> ListaAniversariantes
        {
            get
            {
                return _listaAniversariantes;
            }
            set
            {
                if (_listaAniversariantes != value)
                {
                    _listaAniversariantes = value;
                    RaisePropertyChanged(nameof(ListaAniversariantes));
                }
            }
        }


        private void FiltrarAniversariantes(int mesSelecionado)
        {
            var tiposPessoas=  Enum.GetValues(typeof(TipoPessoa)).Cast<TipoPessoa>();
            var aniversariantes = new List<KeyValuePair<Pessoa, string>>();
            foreach (var tipo in tiposPessoas)
            {

                var lista = ObterAniversariantes(tipo, mesSelecionado)
                    .Select(p=> new KeyValuePair<Pessoa, string>(p, Enum.GetName(typeof(TipoPessoa), tipo)));
                aniversariantes.AddRange(lista);
            }
            this.ListaAniversariantes = new ObservableCollection<KeyValuePair<Pessoa, string>>(aniversariantes.OrderBy(p => p.Key.DataNascimento.Value.Day));

        }
        private static IEnumerable<Pessoa> ObterAniversariantes(TipoPessoa tipo, int mes)
        {
            return Util.Repositorio.ObterLista<Pessoa>(p => p.DataNascimento != null, Util.ObterNomeTabela(tipo))
                .Where(p=>  p.DataNascimento.Value.Month == mes);
        }

        public AniversariantesViewModel()
        {
            this.ListaMeses = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaMeses());
        }
    }
}
