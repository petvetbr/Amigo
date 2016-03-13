using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Amigo
{
    public static class Config
    {
        const string CONFIG_FILE = "config.xml";
        private static IEnumerable<KeyValuePair<int, string>> _categorias;
        private static IEnumerable<KeyValuePair<int, string>> _statusPessoas;
        private static IEnumerable<KeyValuePair<int, string>> _tiposPessoa;
        private static IEnumerable<KeyValuePair<int, string>> _meses;
        private static IEnumerable<KeyValuePair<int, string>> _anos;
        private static IEnumerable<KeyValuePair<int, string>> _statusCaixaTransporte;
        private static IEnumerable<KeyValuePair<int, string>> _situacaoCaixaTransporte;
        private static IEnumerable<KeyValuePair<int, string>> _localizacaoCaixaTransporte;

        private static IEnumerable<KeyValuePair<int, string>> _ambienteAnimal;
        private static IEnumerable<KeyValuePair<int, string>> _ambienteAnimal_statusAnimal;
        private static IEnumerable<KeyValuePair<int, string>> _especieAnimal;
        private static IEnumerable<KeyValuePair<int, string>> _generoAnimal;
        private static IEnumerable<KeyValuePair<int, string>> _tiposTelefones;
        private static IEnumerable<KeyValuePair<int, string>> _statusAnimal;
        private static IEnumerable<string> _listaUf;


        public static string ObterCaminhoExecucao()
        {
            //To get the location the assembly normally resides on disk or the install directory
            var path = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;

            return System.IO.Path.GetDirectoryName(path);
        }

        public static IEnumerable<string> ObterListaUf()
        {
            if (_listaUf != null)
            {
                return _listaUf;
            }

            var _uf = new List<string>();
            var config = ObterCaminhoExecucao() + "\\" + CONFIG_FILE;
            var x = XDocument.Load(config);
            _uf = x.Root.Element("UFs").Elements().Select(p => p.Value.ToString()).ToList();
            _listaUf = _uf;
            return _listaUf;

        }
        private static IEnumerable<KeyValuePair<int, string>> ObterLista(string nomeLista)
        {
            var _uf = new List<string>();
            var config = Path.Combine(ObterCaminhoExecucao(), CONFIG_FILE);
            var x = XDocument.Load(config);
            return x.Root.Element(nomeLista).Elements()
                .Select(p =>
                new KeyValuePair<int, string>(Convert.ToInt32(p.Attribute("Key").Value), p.Attribute("Value").Value.ToString()));

        }
       
        public static IEnumerable<KeyValuePair<int, string>> ObterListaTiposTelefone()
        {
            _tiposTelefones = _tiposTelefones ?? ObterLista("TipoTelefones");
            return _tiposTelefones;
        }



        public static IEnumerable<KeyValuePair<int, string>> ObterListaGeneroAnimal()
        {
            _generoAnimal = _generoAnimal ?? ObterLista("Sexo");
            return _generoAnimal;
        }




        public static IEnumerable<KeyValuePair<int, string>> ObterListaEspecieAnimal()
        {
             _especieAnimal = _especieAnimal ?? ObterLista("Especies");
            return _especieAnimal;
           
        }

        public static IEnumerable<KeyValuePair<int, string>> ObterListaStatusAnimal()
        {

            _statusAnimal = _statusAnimal ?? ObterLista("StatusAnimal");
            return _statusAnimal;
           
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaAmbientesAnimal()
        {
            _ambienteAnimal = _ambienteAnimal ?? ObterLista("AmbienteAnimal");
            return _ambienteAnimal;
        }



        public static IEnumerable<KeyValuePair<int, string>> ObterListaStatusCaixaTransporte()
        {
            _statusCaixaTransporte = _statusCaixaTransporte ?? ObterLista("StatusCaixaTransporte");
            return _statusCaixaTransporte;
           
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaSituacaoCaixaTransporte()
        {
            _situacaoCaixaTransporte = _situacaoCaixaTransporte ?? ObterLista("SituacaoCaixaTransporte");
            return _situacaoCaixaTransporte;
          
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaLocalizacaoCaixaTransporte()
        {
            _localizacaoCaixaTransporte = _localizacaoCaixaTransporte ?? ObterLista("LocalizacaoCaixaTransporte");
            return _localizacaoCaixaTransporte;
            
        }

        public static IEnumerable<KeyValuePair<int, string>> ObterListaPessoasCategoria()
        {
            _categorias = _categorias ?? ObterLista("CategoriaSocios");
            return _categorias;
            
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaPessoasTipos()
        {
            _tiposPessoa = _tiposPessoa ?? ObterLista("TipoSocios");
            return _tiposPessoa;
            
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaPessoasStatus()
        {
            _statusPessoas = _statusPessoas ?? ObterLista("StatusPessoa");
            return _statusPessoas;
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaMeses()
        {
            if (_meses != null)
            {
                return _meses;
            }
            var meses = new List<KeyValuePair<int, string>>();
            for (int i = 1; i <= 12; i++)
            {
                meses.Add(new KeyValuePair<int, string>(i, new DateTime(2016, i, 1).ToString("MMM")));
            }
            _meses = meses;
            return _meses;
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaAnos()
        {
            if (_anos != null)
            {
                return _anos;
            }
            var anos = new List<KeyValuePair<int, string>>();
            for (int i = 2016; i <= 2026; i++)
            {
                anos.Add((new KeyValuePair<int, string>(i, i.ToString())));
            }
            _anos = anos;
            return _anos;
        }

    }
}
