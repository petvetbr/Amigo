using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmigoRepo;
using System.Diagnostics;

namespace AmigoTests
{
    [TestClass]
    public class TesteRepositorio
    {
        const string REPO_TEST = "Teste";
        
        [TestMethod]
        public void TestarRepositorioSocio()
        {
            var repo = new Repositorio(REPO_TEST);
            var s = new Socio() { Nome = "SocioTeste", DataNascimento = new DateTime(2000, 1, 10) };
            var id=repo.SalvarSocio(s);
            Debug.Assert(id.Key && id.Value > 0);
            var socio1 = repo.ObterSocio(id.Value);
            Debug.Assert(socio1 != null && socio1.Id == id.Value && socio1.DataNascimento == new DateTime(2000, 1, 10));
            var resultado = repo.ApagarSocio(id.Value);
            var resultadoObter = repo.ObterSocio(id.Value);
            Debug.Assert(resultado && resultadoObter == null);
        }
        
    }
}
