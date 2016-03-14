using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IAnimal : IRepositorio, IObservacao
    {
        string Tutor { get; set; }
        string Nome { get; set; }
        int Especie { get; set; }
        int Sexo { get; set; }
        DateTime? DataNascimento { get; set; }
        DateTime? DataCadastro { get; set; }
        float Peso { get; set; }
        string Raca { get; set; }
        int Ambiente { get; set; }
        bool Castrado { get; set; }
        Pessoa Clinica { get; set; }
        string Foto { get; set; }
        ObservableCollection<IVacinaVermifugo> Vacinas { get; set; }
        ObservableCollection<IVacinaVermifugo> Vermifugos { get; set; }
        int Status { get; set; }
    }
}
