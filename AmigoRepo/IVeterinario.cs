using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IVeterinario:IPessoa
    {
        int Crmv { get; set; }
        string Uf { get; set; }
    }
}
