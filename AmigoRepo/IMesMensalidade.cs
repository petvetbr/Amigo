using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IMesMensalidade: IRepositorio
    {
        int Ano { get; set; }
        int Mes { get; set; }
        IChaveValor<int, string> Situacao { get; set; }
    }
}
