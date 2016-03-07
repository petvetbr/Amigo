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
        IChaveValor<int, string> Especie { get; set; }
        IChaveValor<int, string> Sexo { get; set; }
        DateTime DataNascimento { get; set; }
        int Peso { get; set; }
        IChaveValor<int, string> Raca { get; set; }
        IChaveValor<int, string> Ambiente { get; set; }
        bool Castrado { get; set; }
        IVeterinario Clinica { get; set; }
        IEnumerable<IChaveValor<DateTime, IVacinaVermifugo>> Vacinas { get; set; }
        IEnumerable<IChaveValor<DateTime, IVacinaVermifugo>> Vermifugos { get; set; }
        IChaveValor<int, string> Status { get; set; }
    }
}
