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
    public class CaixaTransporteViewModel:ViewModelBase
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
        CaixaTransporte _caixa;
        public CaixaTransporte Caixa
        {
            get
            {
                return _caixa;
            }
            set
            {
                if (_caixa != value)
                {
                    _caixa = value;
                    RaisePropertyChanged(nameof(Caixa));
                }
            }
        }
        ObservableCollection<KeyValuePair<int, string>> _listaLocalizacao;
        public ObservableCollection<KeyValuePair<int, string>> ListaLocalizacao
        {
            get
            {
                return _listaLocalizacao;
            }
            set
            {
                if (_listaLocalizacao != value)
                {
                    _listaLocalizacao = value;
                    RaisePropertyChanged(nameof(ListaLocalizacao));
                }
            }
        }
        ObservableCollection<ICaixaTransporte> _listaItens;
        public ObservableCollection<ICaixaTransporte> ListaItens
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
        public CaixaTransporteViewModel()
        {
            this.SalvarCommand = new RelayCommand(Salvar, () => Caixa != null && Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Alterar));
            this.ExcluiCommand = new RelayCommand(Excluir, () => Caixa!=null && Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Excluir));
            this.PesquisaCommand = new RelayCommand(Pesquisar);
            this.NovoItemCommand = new RelayCommand(CriarNovoItem, () => Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Adicionar));
            this.ListaLocalizacao=new ObservableCollection<KeyValuePair<int,string>>(Config.ObterListaLocalizacaoCaixaTransporte());
            RefreshLista();
            ExpanderAberto = true;
            
        }

        private void CriarNovoItem()
        {

            
            var caixa = new CaixaTransporte() { DataCadastro = DateTime.Now };
            if (Util.Repositorio.ObterLista<CaixaTransporte>().Any())
            {
                var maxAtual = Util.Repositorio.ObterLista<CaixaTransporte>().Max(p => p.Numero);
                caixa.Numero = ++maxAtual;
            }
            else
            {
                caixa.Numero = 1;
            }
            this.Caixa = caixa;
            ExpanderAberto = false;
        }



        private void Excluir()
        {
            if (!Util.Repositorio.Apagar<CaixaTransporte>(x => x.Id == this.Caixa.Id))
            {
                return;
            }
            this.Caixa = null;
            RefreshLista();
            ExpanderAberto = true;
        }

        private void Salvar()
        {
            if (!Util.Repositorio.Salvar<CaixaTransporte>(_caixa).Key)
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
            RefreshLista(x => x.Identificacao.Contains(FiltroPesquisa));
        }

       
        private void RefreshLista(Expression<Func<CaixaTransporte, bool>> expression = null)
        {
            var lista = Util.Repositorio.ObterLista<CaixaTransporte>(expression).OrderBy(p=>p.Identificacao);
            this.ListaItens = new ObservableCollection<ICaixaTransporte>(lista);
        }
    }
}
