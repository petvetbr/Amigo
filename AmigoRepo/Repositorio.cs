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
        AmigoDb db;
        public Repositorio(string nomeRepositorio, string caminho = null)
        {
            if (caminho == null)
            {
                var path = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;

                caminho= System.IO.Path.GetDirectoryName(path);
            }
           
            this.NomeRepositorio = nomeRepositorio;
            this.CaminhoRepositorio = string.Format("{0}\\{1}.db", caminho, nomeRepositorio);
            db = new AmigoDb(CaminhoRepositorio);

        }
        public string Dump()
        {
            return db.Dump();
        }
    

        public KeyValuePair<bool, int> Salvar<T>(T item, string nomeTabela=null) where T :  class, IRepositorio, new()
        {
            try
            {
                nomeTabela = nomeTabela ?? ObterPlural<T>();
                var itens = db.GetCollection<T>(nomeTabela);
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


        public Mensalidades ObterMensalidades(Expression<Func<Mensalidades, bool>> exp, string nomeTabela = null)
        {
            try
            {
                nomeTabela = nomeTabela ?? ObterPlural<Mensalidades>();

                var mensalidades = db.GetCollection<Mensalidades>(nomeTabela)
                    .Include(x => x.Socio)
                    .FindAll()
                    .Where(exp.Compile());
                    
               
                return mensalidades.FirstOrDefault(); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<EmprestimoCaixaTransporte> ObterEmprestimosCaixaTransporteComCaixa(Func<EmprestimoCaixaTransporte, bool> exp, string nomeTabela = null)
        {
            try
            {
                nomeTabela = nomeTabela ?? ObterPlural<EmprestimoCaixaTransporte>();

                var emprestimos = db.GetCollection<EmprestimoCaixaTransporte>(nomeTabela)
                    .Include(x => x.CaixaTransporte)
                    .FindAll();
                if (exp != null)
                {
                    emprestimos = emprestimos.Where(exp);
                }

                return emprestimos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Animal> ObterAnimal(Func<Animal, bool> exp, string nomeTabela = null)
        {
            try
            {
                nomeTabela = nomeTabela ?? ObterPlural<Animal>();

                var animais = db.GetCollection<Animal>(nomeTabela)
                    .Include(x => x.Clinica)
                    .FindAll();
                if (exp != null)
                {
                    animais = animais.Where(exp);
                }

                return animais;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public T Obter<T>(Expression<Func<T,bool>> exp, string nomeTabela = null) where T: class,new()
        {
            try
            {
                nomeTabela = nomeTabela ?? ObterPlural<T>();
                var socios = db.GetCollection<T>(nomeTabela);
                return socios.FindOne(exp);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IEnumerable<T> ObterLista<T>(Expression<Func<T, bool>> exp=null, string nomeTabela = null) where T : class, new()
        {
            try
            {
                nomeTabela = nomeTabela ?? ObterPlural<T>();
                var socios = db.GetCollection<T>(nomeTabela);
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

        
        public bool Apagar<T>(Expression<Func<T, bool>> exp, string nomeTabela = null) where T : class, new()

        {
            try
            {
                nomeTabela = nomeTabela ?? ObterPlural<T>();
                var socios = db.GetCollection<T>(nomeTabela);
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
