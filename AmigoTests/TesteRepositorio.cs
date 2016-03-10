using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmigoRepo;
using System.Diagnostics;
using System.Threading;

namespace AmigoTests
{
    [TestClass]
    public class TesteRepositorio
    {
        const string REPO_TEST = "Teste";
        
        [TestMethod]
        public void TestarRepositorioSocio()
        {
            using (var repo = new Repositorio(REPO_TEST))
            {
                var s = new Pessoa() { Nome = "SocioTeste", DataNascimento = new DateTime(2000, 1, 10) };
                var id = repo.Salvar(s);
                Debug.Assert(id.Key && id.Value > 0);
                Thread.Sleep(100);
                var socio1 = repo.Obter<Pessoa>(x=> x.Id==id.Value);
                Debug.Assert(socio1 != null && socio1.Id == id.Value && socio1.DataNascimento == new DateTime(2000, 1, 10));
                var resultado = repo.Apagar<Pessoa>(x => x.Id == id.Value);
                var resultadoObter = repo.Obter<Pessoa>(x => x.Id == id.Value);
                Debug.Assert(resultado && resultadoObter == null);
            }
        }
        
    }
}
