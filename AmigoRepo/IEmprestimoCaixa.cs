using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IEmprestimoCaixa:IRepositorio,IObservacao
    {
        IPessoa Responsavel { get; set; }
        DateTime DataSaida { get; set; }
        DateTime DataRetorno { get; set; }
        IAnimal Animal { get; set; }
        int Status { get; set; }
        int Situacao { get; set; }
    }
}
