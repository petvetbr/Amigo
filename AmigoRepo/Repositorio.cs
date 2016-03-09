using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class Repositorio:IDisposable
    {
        private readonly string NomeRepositorio;
        private readonly string CaminhoRepositorio;
        LiteDatabase db;
        public Repositorio(string nomeRepositorio, string caminho=null)
        {
            caminho = caminho ?? @"e:\acpa\";
            this.NomeRepositorio = nomeRepositorio;
            this.CaminhoRepositorio = string.Format("{0}{1}.db", caminho, nomeRepositorio);
            db=new LiteDatabase(CaminhoRepositorio);
        }
        

        public KeyValuePair<bool, int> SalvarSocio(Socio socio)
        {
            try
            {
                // Open database (or create if not exits)
               
                    // Get customer collection

                    var socios = db.GetCollection<Socio>("Socios");
                    Socio socioAntigo = null;
                    if (socio.Id > 0)
                    {
                        socioAntigo = socios.FindById(socio.Id);
                        socio.Id = socioAntigo.Id;
                        socios.Update(socio);
                    }
                    else
                    {
                        AssociarRepositorio(socio);
                        socios.Insert(socio);
                    }
                    socios.EnsureIndex(x => x.Id);

              
                return new KeyValuePair<bool, int>(true, socio.Id);
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public Socio ObterSocio(int id)
        {
            try
            {
                Socio socio = null;
                
                    // Get customer collection

                    var socios = db.GetCollection<Socio>("Socios");
                    socio = socios.FindById(id);
               
                return socio;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public bool ApagarSocio(int id)
        {
            try
            {
               

                    var socios = db.GetCollection<Socio>("Socios");
                    socios.Delete(id);
               
                return true;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void AssociarRepositorio(IRepositorio item)
        {
            item.Repositorio = this.NomeRepositorio;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
