using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class MensalidadesViewModel : ViewModelBase
    {

        public RelayCommand SalvarCommand
        {
            get;
            private set;
        }

        IMensalidades _mensalidades;
        public IMensalidades Mensalidades
        {
            get
            {
                return _mensalidades;
            }
            set
            {
                if (_mensalidades != value)
                {
                    _mensalidades = value;
                    RaisePropertyChanged(nameof(Mensalidades));
                    if (value != null)
                    {
                        this.Pagamentos = new ObservableCollection<IMesMensalidade>(_mensalidades.Pagamentos.Where(p => p.Ano == _anoSelecionado));
                    }
                    else
                    {
                        this.Pagamentos = null;
                    }
                }
            }
        }
        ObservableCollection<IMesMensalidade> _pagamentos;
        public ObservableCollection<IMesMensalidade> Pagamentos
        {
            get
            {
                return _pagamentos;
            }
            set
            {
                if (_pagamentos != value)
                {
                    _pagamentos = value;
                    RaisePropertyChanged(nameof(Pagamentos));
                }
            }
        }


        ObservableCollection<int> _anos;
        public ObservableCollection<int> ListaAnos
        {
            get
            {
                return _anos;
            }
            set
            {
                if (_anos != value)
                {
                    _anos = value;
                    RaisePropertyChanged(nameof(ListaAnos));
                }
            }
        }



        ObservableCollection<KeyValuePair<int, string>> _listaSocios;
        public ObservableCollection<KeyValuePair<int, string>> ListaSocios
        {
            get
            {
                return _listaSocios;
            }
            set
            {
                if (_listaSocios != value)
                {
                    _listaSocios = value;
                    RaisePropertyChanged(nameof(ListaSocios));
                }
            }
        }

        KeyValuePair<int, string> _socioSelecionado;
        public KeyValuePair<int, string> SocioSelecionado
        {
            get
            {
                return _socioSelecionado;
            }
            set
            {
                if (_socioSelecionado.Key == value.Key) return;
                _socioSelecionado = value;
                RaisePropertyChanged(nameof(SocioSelecionado));
                AtualizaDados();
            }
        }
        int? _anoSelecionado;
        public int? AnoSelecionado
        {
            get
            {
                return _anoSelecionado;
            }
            set
            {
                if (_anoSelecionado != value)
                {
                    _anoSelecionado = value;
                    RaisePropertyChanged(nameof(AnoSelecionado));
                    AtualizaDados();
                }
            }
        }

        public MensalidadesViewModel()
        {

            this.ListaAnos = new ObservableCollection<int>(Config.ObterListaAnos().Select(p => p.Key));
            this.ListaSocios = new ObservableCollection<KeyValuePair<int, string>>(Util.ObterListaSocios());
            this.SalvarCommand = new RelayCommand(Salvar, () => this.Mensalidades != null);
        }

        private void Salvar()
        {
            
        }

        private void AtualizaDados()
        {
            if (_anoSelecionado == null || _socioSelecionado.Key == 0) return;
            var repo = Util.Repositorio;
            var socio = repo.Obter<Pessoa>(p => p.Id == _socioSelecionado.Key, "Socios");
            var mensalidade = repo.Obter<Mensalidades>(p => p.Socio==socio);
            if(mensalidade==null)
            {
                mensalidade = new AmigoRepo.Mensalidades()
                {
                    Socio = repo.Obter<Pessoa>(p => p.Id == _socioSelecionado.Key, "Socios"),
                    Pagamentos = GerarMensalidadesAno(_anoSelecionado.Value).ToList()
                };
            }
            else if (!mensalidade.Pagamentos.Any(p => p.Ano == _anoSelecionado.Value))
            {
                GerarMensalidadesAno(_anoSelecionado.Value).Select(p => { mensalidade.Pagamentos.Add(p); return true; });
            }

            this.Mensalidades = mensalidade;

        }
        private IEnumerable<IMesMensalidade>  GerarMensalidadesAno(int ano)
        {
            for (int i = 1; i <= 12; i++)
            {
                yield return new MesMensalidade() {  Ano=ano, Mes=i };
            }
        }
    }
}
