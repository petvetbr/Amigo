using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface ICaixaTransporte:IObservacao, IRepositorio
    {
      
        int Altura { get; set; }
        int Largura { get; set; }
        int Comprimento { get; set; }
        int Peso { get; set; }
        string Identificacao { get; set; }
        int Localizacao { get; set; }
        
        

    }
}
