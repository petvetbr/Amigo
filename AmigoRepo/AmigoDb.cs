using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoRepo
{
    public class AmigoDb:LiteDatabase
    {
        public AmigoDb( string conn):base(conn)
        {

        }
        protected override void OnModelCreating(BsonMapper mapper)
        {
            mapper.Entity<Mensalidades>()
                  .Id(x => x.Id)
                  .DbRef(x => x.Socio, "Socios");

        }

    }
}
