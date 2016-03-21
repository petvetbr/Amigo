using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Amigo.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        public RelayCommand EntrarCommand
        {
            get;
            private set;
        }

        string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    RaisePropertyChanged(nameof(Login));
                }
            }
        }


        private PasswordBox _pwb;
        public LoginViewModel()
        {
            Messenger.Default.Register<PasswordBox>(this, "login", (pwb) => {
                _pwb = pwb;
            });
            this.EntrarCommand = new RelayCommand(Entrar);
            if(!Util.CheckTemUsuarios())
            {
                Continuar();
            }
        }

        private void Entrar()
        {
            var result = Util.CheckLogin(_login, _pwb.Password);
            if (result.Key)
            {
                Config.UsuarioAtual = (Usuario)result.Value;
                Continuar();
                return;
            }
            MessageBox.Show(result.Value.ToString());

        }

        private static void Continuar()
        {
          
            var mw = new MainWindow();
            Messenger.Default.Send(new CloseWindowMessage(), "LoginWindow");
            mw.ShowDialog();
        }
    }
}
