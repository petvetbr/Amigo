using AmigoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public enum TipoPessoa
    {
        Socio,
        Veterinario,
        Clinica,
        Cliente,
        MoradorComunitario,
        Fornecedor,
        Entidade,
        Parceiro,
        Doador,
        Patrocinador

    }
    public class PessoaMessageArgs
    {
        public TipoPessoa Tipo { get; set; }
        public IPessoa Pessoa { get; set; }

    }
}
