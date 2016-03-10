using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IAnimal:IRepositorio, IObservacao
    {
        IPessoa Tutor { get; set; }
        string Nome { get; set; }
        int Especie { get; set; }
        int Sexo { get; set; }
        DateTime DataNascimento { get; set; }
        int Peso { get; set; }
        int Raca { get; set; }
        int Ambiente { get; set; }
        bool Castrado { get; set; }
        IPessoa Clinica { get; set; }
        string Foto { get; set; }
        IEnumerable<IChaveValor<DateTime, IVacinaVermifugo>> Vacinas { get; set; }
        IEnumerable<IChaveValor<DateTime, IVacinaVermifugo>> Vermifugos { get; set; }
        int Status { get; set; }
    }
}
