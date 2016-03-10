using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IPessoa: IRepositorio, IObservacao
    {
        DateTime? DataCadastro { get; set; }
        DateTime? DataNascimento { get; set; }
        string Cidade { get; set; }
        string UF { get; set; }
        string CEP { get; set; }
        string Endereco { get; set; }
        string Nome { get; set; }
        string NomeFantasia { get; set; }
        string NomeRepresentante { get; set; }
        string Email { get; set; }
        string Cpf_Cnpj { get; set; }
        string TipoPessoa { get; set; }
        string Homepage { get; set; }
        IEnumerable<ITelefone> Telefones { get; set; }
        int Status { get; set; }
        int Categoria { get; set; }
        int Tipo { get; set; }

    }
}
