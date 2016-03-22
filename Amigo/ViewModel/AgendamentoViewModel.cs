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
    public class AgendamentoViewModel : ViewModelBase
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
        #endregion
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
        ObservableCollection<Agendamento> _listaItens;
        public ObservableCollection<Agendamento> ListaItens
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
        Agendamento _agendamento;
        public Agendamento Agendamento
        {
            get
            {
                return _agendamento;
            }
            set
            {
                if (_agendamento != value)
                {
                    _agendamento = value;
                    RaisePropertyChanged(nameof(Agendamento));
                }
            }
        }

        public AgendamentoViewModel()
        {
            this.SalvarCommand = new RelayCommand(Salvar, () => Agendamento != null && Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Alterar));
            this.ExcluiCommand = new RelayCommand(Excluir, () => Agendamento != null && Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Excluir));
            this.PesquisaCommand = new RelayCommand(Pesquisar);
            this.NovoItemCommand = new RelayCommand(CriarNovoItem, () => Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Adicionar));

        }

        private void CriarNovoItem()
        {
            var Agendamento = new Agendamento() { DataCadastro = DateTime.Now };
            if (Util.Repositorio.ObterLista<Agendamento>().Any())
            {
                var maxAtual = Util.Repositorio.ObterLista<Agendamento>().Max(p => p.Numero);
                Agendamento.Numero = ++maxAtual;
            }
            else
            {
                Agendamento.Numero = 1;
            }
            this.Agendamento = Agendamento;
            ExpanderAberto = false;
        }

        private void Pesquisar()
        {
            if (string.IsNullOrWhiteSpace(FiltroPesquisa))
            {
                RefreshLista();
                return;
            }
            RefreshLista(x => x.NomePessoa.Contains(FiltroPesquisa));
        }

        private void Excluir()
        {
            if (!Util.Repositorio.Apagar<Agendamento>(x => x.Id == this.Agendamento.Id))
            {
                return;
            }
            this.Agendamento = null;
            RefreshLista();
            ExpanderAberto = true;
        }

        private void Salvar()
        {
            if (!Util.Repositorio.Salvar<Agendamento>(_agendamento).Key)
            {
                return;
            }
            RefreshLista();
            ExpanderAberto = true;
        }
        private void RefreshLista(Expression<Func<Agendamento, bool>> expression = null)
        {
            var lista = Util.Repositorio.ObterLista<Agendamento>(expression).OrderBy(p => p.DataAgenda);
            this.ListaItens = new ObservableCollection<Agendamento>(lista);
        }

    }
}
