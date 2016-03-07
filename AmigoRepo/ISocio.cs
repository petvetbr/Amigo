using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface ISocio:IRepositorio
    {
        DateTime DataCadastro { get; set; }
        DateTime DataNascimento { get; set; }
        string Cidade { get; set; }
        string UF { get; set; }
        string CEP { get; set; }
        string Endereco { get; set; }
        int Numero { get; set; }
        string Nome { get; set; }
        string Email { get; set; }
        IEnumerable<ITelefone> Telefones { get; set; }
        IChaveValor<int, string> Categoria { get; set; }
        IChaveValor<int, string> Tipo { get; set; }
        IChaveValor<int,string> Status { get; set; }
        string Observacao { get; set; }
    }
}
