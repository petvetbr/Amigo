using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface ILancamentoCaixa:IRepositorio, IObservacao
    {
        DateTime Data { get; set; }
        Decimal Valor { get; set; }
    }
}
