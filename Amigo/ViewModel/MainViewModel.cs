using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using AmigoRepo;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Media.Imaging;
using System.Windows;
using Alienlab.Zip;
using System.IO;

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
        public RelayCommand<int> MenuCadastroCommand
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
        public RelayCommand MenuCadastroAnimaisCommand
        {
            get;
            private set;
        }

        public RelayCommand MenuCopiaDadosCommand
        {
            get;
            private set;
        }
        public RelayCommand MenuSobreCommand
        {
            get;
            private set;
        }


        public RelayCommand MenuRestauraDadosCommand
        {
            get;
            private set;
        }

        public RelayCommand MenuCalculadoraCommand
        {
            get;
            private set;
        }
        public RelayCommand MenuUsuariosCommand
        {
            get;
            private set;
        }

        BitmapImage _logo;
        public BitmapImage Logo
        {
            get
            {
                return _logo;
            }
            set
            {
                if (_logo != value)
                {
                    _logo = value;
                    RaisePropertyChanged(nameof(Logo));
                }
            }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {

            MenuCadastroCommand = new RelayCommand<int>(MenuCadastro);
            MenuCadastroCaixasTransporteCommand = new RelayCommand(MenuCadastroCaixasTransporte);
            MenuFluxoCaixaCommand = new RelayCommand(MenuFluxoCaixa);
            MenuServicosCaixaTransporteCommand = new RelayCommand(ServicosCaixaTransporte);
            MenuMensalidadesCommand = new RelayCommand(AbrirMensalidades);
            MenuCadastroAnimaisCommand = new RelayCommand(() => new AnimalWindow().ShowDialog());
            MenuSobreCommand = new RelayCommand(() => new SobreWindow().ShowDialog());
            var logo = Config.ObterCaminhoLogo();
            if (logo != null)
            {
                var uriSource = new Uri(logo, UriKind.Absolute);
                this.Logo = new BitmapImage(uriSource);
            }
            MenuCopiaDadosCommand = new RelayCommand(CopiarDados);
            MenuRestauraDadosCommand = new RelayCommand(RestauraDados, () => false);
            MenuCalculadoraCommand= new RelayCommand(()=> System.Diagnostics.Process.Start("calc") );
            MenuUsuariosCommand = new RelayCommand(Usuarios);
        }

        private void Usuarios()
        {
            var uw = new UserWindow();
            uw.ShowDialog();
        }

        private void RestauraDados()
        {
            throw new NotImplementedException();
        }

        private void CopiarDados()
        {
            string token= "CopiarDados";
            var input = new InputWindow();
            Messenger.Default.Register<InputResultMessage>(this, token, ContinuarCopiarDados);
            Messenger.Default.Send(new ShowInputMessage() { Pergunta = "Qual senha deseja utilizar para proteger o arquivo?", Titulo = "Senha de proteção do arquivo", Token =token  });
            input.ShowDialog();
        }

        private void ContinuarCopiarDados(InputResultMessage msg)
        {
            Messenger.Default.Unregister<InputResultMessage>(this, msg.Token);
            if (!msg.Resultado) return;

            var isDump = false;
            if (isDump)
            {
                var dump = Util.Repositorio.Dump();
                using (var sw = File.CreateText("dump.txt"))
                {
                    sw.Write(dump);
                }

                using (var zip = new ZipFile())
                {
                    zip.Password = msg.Texto;
                    zip.AddFile("dump.txt");
                    zip.Save("Backup.zip");

                }
                File.Delete("dump.txt");
            }
            else
            {
                using (var zip = new ZipFile())
                {
                    zip.Password = msg.Texto;
                    zip.AddFile("dados.db");
                    zip.Save("Backup.zip");

                }
            }

            MessageBox.Show("Cópia de segurança gerada: " + Config.ObterCaminhoExecucao() + @"\Backup.zip");
            
        }

        private void MenuCadastro(int tipoPessoa)
        {
            var tp = (TipoPessoa)Enum.ToObject(typeof(TipoPessoa), tipoPessoa);
            var pw = new PessoasWindow();
            Messenger.Default.Send(tp);
            pw.ShowDialog();
        }

        private void AbrirMensalidades()
        {
            new MensalidadesWindow().ShowDialog();
        }

        private void ServicosCaixaTransporte()
        {
            new EmprestimoCaixaWindow().ShowDialog();
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




    }
}