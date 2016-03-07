using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface ISocio: IPessoa
    {
        
        IChaveValor<int, string> Categoria { get; set; }
        IChaveValor<int, string> Tipo { get; set; }
        
    }
}
