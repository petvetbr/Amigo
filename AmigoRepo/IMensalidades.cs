using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IMensalidades:IRepositorio, IObservacao
    {
        Pessoa Socio { get; set; }
        IList<IMesMensalidade> Pagamentos { get; set; }
    }
}
