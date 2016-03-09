using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AmigoRepo
{
    public class Repositorio : IDisposable
    {
        private readonly string NomeRepositorio;
        private readonly string CaminhoRepositorio;
        LiteDatabase db;
        public Repositorio(string nomeRepositorio, string caminho = null)
        {
            caminho = caminho ?? @"e:\acpa\";
            this.NomeRepositorio = nomeRepositorio;
            this.CaminhoRepositorio = string.Format("{0}{1}.db", caminho, nomeRepositorio);
            db = new LiteDatabase(CaminhoRepositorio);
        }

    

        public KeyValuePair<bool, int> Salvar<T>(T item) where T :  class, IRepositorio, new()
        {
            try
            {

                var itens = db.GetCollection<T>(ObterPlural<T>());
                T itemAntigo = null;
                if (item.Id > 0)
                {
                    itemAntigo = itens.FindById(new BsonValue(item.Id));
                    item.Id = itemAntigo.Id;
                    itens.Update(item);
                }
                else
                {
                    AssociarRepositorio(item);
                    itens.Insert(item);
                }
                itens.EnsureIndex(x => x.Id);


                return new KeyValuePair<bool, int>(true, item.Id);
            }
            catch (Exception)
            {
                throw;
            }


        }
        private static string ObterPlural<T>()
            {
            var s = typeof(T).Name;
            var nome = s + "s";
            return nome;
        }
        public T Obter<T>(Expression<Func<T,bool>> exp) where T: class,new()
        {
            try
            {
                
                var socios = db.GetCollection<T>(ObterPlural<T>());
                return socios.FindOne(exp);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IEnumerable<T> ObterLista<T>(Expression<Func<T, bool>> exp=null) where T : class, new()
        {
            try
            {
                var socios = db.GetCollection<T>(ObterPlural<T>());
                if(exp==null)
                {
                    return socios.FindAll();
                }
                return socios.Find(exp);
            }
            catch (Exception)
            {

                throw;
            }

        }

        
        public bool Apagar<T>(Expression<Func<T, bool>> exp) where T : class, new()

        {
            try
            {
                var socios = db.GetCollection<T>(ObterPlural<T>());
                socios.Delete(exp);
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
