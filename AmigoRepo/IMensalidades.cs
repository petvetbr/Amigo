using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IMensalidades:IRepositorio, IObservacao
    {
        IPessoa Socio { get; set; }
        IList<IMesMensalidade> Pagamentos { get; set; }
    }
}
