using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface ITelefone
    {
        string Descricao { get; set; }
        string Ddd { get; set; }
        string Numero { get; set; }
    }
}
