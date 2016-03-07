using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IVacinaVermifugo:IRepositorio
    {
        string Descricao {get;set;}
        string Fabricante { get; set; }
        string Lote { get; set; }
        string Tipo { get; set; }
    }
}
