using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public class Repositorio
    {

        public bool SalvarSocio(Socio socio)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(@"Amigo.db"))
            {
                // Get customer collection
                var socios = db.GetCollection<Socio>("Socios");
                Socio socioAntigo = null;
                if(socio.Id>0)
                {
                    socioAntigo = socios.FindById(socio.Id);
                    socio.Id = socioAntigo.Id;
                    socios.Update(socio);
                }
                else
                {
                    socios.Insert(socio);
                }
                socios.EnsureIndex(x => x.Id);

            }
            return true;

        }
    }
}
