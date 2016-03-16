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
            mapper.Entity<Animal>()
              .Id(x => x.Id)
              .DbRef(x => x.Clinica, "Clinicas");
            mapper.Entity<EmprestimoCaixaTransporte>()
                 .Id(x => x.Id)
                .DbRef(x => x.CaixaTransporte, "CaixaTransportes");
        }
        public string Dump()
        {
            using (var writer = new StringWriter())
            {
                foreach (var name in this.GetCollectionNames())
                {
                    var col = this.GetCollection(name);
                    var indexes = col.GetIndexes().Where(x => x["field"] != "_id");

                    writer.WriteLine("-- Collection '{0}'", name);

                    foreach (var index in indexes)
                    {
                        writer.WriteLine("db.{0}.ensureIndex {1} {2}",
                            name,
                            index["field"].AsString,
                            JsonSerializer.Serialize(index["options"].AsDocument));
                    }

                    foreach (var doc in col.Find(Query.All()))
                    {
                        writer.WriteLine("db.{0}.insert {1}", name, JsonSerializer.Serialize(doc, false, true));
                    }
                }
                return writer.ToString();
            }
        }
    }
}
