using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IFluxoCaixa : IRepositorio, IObservacao
    {
        int Ano { get; set; }
        int Mes { get; set; }
        decimal SaldoAnterior { get; set; }
        ObservableCollection<ILancamentoCaixa> Lancamentos { get; set; }

    }
}
