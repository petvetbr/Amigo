using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using AmigoRepo;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

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
        public RelayCommand MenuCadastroSociosCommand
        {
            get;
            private set;
        }
        public RelayCommand MenuCadastroCaixasTransporteCommand
        {
            get;
            private set;
        }
      
        public RelayCommand MenuServicosCaixaTransporteCommand
        {
            get;
            private set;
        }
        public RelayCommand MenuFluxoCaixaCommand
        {
            get;
            private set;
        }
        public RelayCommand MenuMensalidadesCommand
        {
            get;
            private set;
        }



        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
           
            MenuCadastroSociosCommand = new RelayCommand(MenuCadastroSocios);
            MenuCadastroCaixasTransporteCommand = new RelayCommand(MenuCadastroCaixasTransporte);
            MenuFluxoCaixaCommand = new RelayCommand(MenuFluxoCaixa);
            MenuServicosCaixaTransporteCommand = new RelayCommand(ServicosCaixaTransporte);
            MenuMensalidadesCommand = new RelayCommand(AbrirMensalidades);
        }

        private void AbrirMensalidades()
        {
            new MensalidadesWindow().ShowDialog();
        }

        private void ServicosCaixaTransporte()
        {
            new ServicoCaixaTransporteWindow().ShowDialog();
        }

        private void MenuFluxoCaixa()
        {
            var flux = new FluxoCaixaWindow();
            flux.ShowDialog();
        }

        private void MenuCadastroCaixasTransporte()
        {
            var ctw = new CaixaTransporteWindow();
            ctw.ShowDialog();
        }

        private void MenuCadastroSocios()
        {
            var pw = new PessoasWindow();
            Messenger.Default.Send(TipoPessoa.Socio);
            pw.ShowDialog();

        }


    }
}