using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface ILancamentoCaixa:IRepositorio, IObservacao
    {
        string Descricao { get; set; }
        DateTime Data { get; set; }
        Decimal Valor { get; set; }
    }
}
