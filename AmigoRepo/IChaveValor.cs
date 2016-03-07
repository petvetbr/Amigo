using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IChaveValor<TipoChave,TipoValor>
    {
        TipoChave Chave { get; set; }
        TipoValor Valor { get;  set; }
    }
}
