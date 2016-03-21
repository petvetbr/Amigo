using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class InputViewModel:ViewModelBase
    {
        public RelayCommand OkCommand
        {
            get;
            private set;
        }
        public RelayCommand CancelCommand
        {
            get;
            private set;
        }

        string _textoInput;
        public string TextoInput
        {
            get
            {
                return _textoInput;
            }
            set
            {
                if (_textoInput != value)
                {
                    _textoInput = value;
                    RaisePropertyChanged(nameof(TextoInput));
                }
            }
        }
        string _pergunta;
        public string Pergunta
        {
            get
            {
                return _pergunta;
            }
            set
            {
                if (_pergunta != value)
                {
                    _pergunta = value;
                    RaisePropertyChanged(nameof(Pergunta));
                }
            }
        }
        string _titulo;
        public string Titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                if (_titulo != value)
                {
                    _titulo = value;
                    RaisePropertyChanged(nameof(Titulo));
                }
            }
        }

        object _token;
        public InputViewModel()
        {
            OkCommand = new RelayCommand(Ok);
            CancelCommand = new RelayCommand(Cancel);
            Messenger.Default.Register<ShowInputMessage>(this, Inicializar);
        }

        private void Inicializar(ShowInputMessage msg)
        {
            this._token = msg.Token;
            this.Titulo = msg.Titulo;
            this.Pergunta = msg.Pergunta;
        }

        private void Cancel()
        {
            Messenger.Default.Send(new InputResultMessage() { Resultado = false, Token = _token }, _token);
            Close();
        }

        private void Ok()
        {
            Messenger.Default.Send(new InputResultMessage() { Resultado = true, Texto=_textoInput, Token = _token }, _token);
            Close();
        }
        private void Close()
        {
            Messenger.Default.Send(new CloseWindowMessage(), InputWindow.CLOSE_TOKEN);
        }
    }
}
