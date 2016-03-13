using AmigoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Amigo
{
    public static class Util
    {
       public static Repositorio Repositorio { get; set; }
       public static IEnumerable<KeyValuePair<int,string>> ObterListaSocios()
        {
            return Repositorio.ObterLista<Pessoa>(nomeTabela: "Socios")
                .Select((p => new KeyValuePair<int,string> (p.Id, p.Nome)));
        }
    }
   
}
