using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo
{
    public class InputResultMessage: MessageBase
    {
        public bool Resultado { get; set; }
        public string Texto { get; set; }
        public object Token { get; set; }
    }
    public class ShowInputMessage : MessageBase
    {
        public string Titulo { get; set; }
        public string Pergunta { get; set; }
        public object Token { get; set; }
    }
}
