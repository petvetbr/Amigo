using AmigoRepo;
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
        static string CONFIG_FILE = Properties.Settings.Default.ArquivoConfig;
        private static List<KeyValuePair<int, string>> _categorias;
        private static List<KeyValuePair<int, string>> _statusPessoas;
        private static List<KeyValuePair<int, string>> _tiposPessoa;
        private static List<KeyValuePair<int, string>> _meses;
        private static List<KeyValuePair<int, string>> _anos;
        private static List<KeyValuePair<int, string>> _statusCaixaTransporte;
        private static List<KeyValuePair<int, string>> _situacaoCaixaTransporte;
        private static List<KeyValuePair<int, string>> _localizacaoCaixaTransporte;

        private static List<KeyValuePair<int, string>> _ambienteAnimal;
        private static List<KeyValuePair<int, string>> _especieAnimal;
        private static List<KeyValuePair<int, string>> _generoAnimal;
        private static List<KeyValuePair<int, string>> _tiposTelefones;
        private static List<KeyValuePair<int, string>> _statusAnimal;
        private static List<KeyValuePair<int, string>> _niveisUsuario;
        private static List<string> _listaUf;
        private static List<string> _listaFabricantesVacina;
        private static List<string> _listaFabricantesVermifugo;
        private static List<string> _listaTiposVacina;
        private static List<string> _listaRacasCaes;
        private static List<string> _listaRacasGatos;

        public static Usuario UsuarioAtual { get; set; }

        public static string ObterCaminhoExecucao()
        {
            //To get the location the assembly normally resides on disk or the install directory
            var path = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;

            return System.IO.Path.GetDirectoryName(path);
        }


        public static IEnumerable<string> ObterListaUf()
        {
            
            _listaUf =_listaUf??ObterListaString("UFs").ToList();
            return _listaUf;

        }
        public static IEnumerable<string> ObterListaFabricantesVacina()
        {

            _listaFabricantesVacina = _listaFabricantesVacina ?? ObterListaString("FabricanteVacina").ToList();
            return _listaFabricantesVacina;

        }
        public static IEnumerable<string> ObterListaFabricantesVermifugo()
        {

            _listaFabricantesVermifugo = _listaFabricantesVermifugo ?? ObterListaString("FabricanteVermifugo").ToList();
            return _listaFabricantesVermifugo;

        }
        public static IEnumerable<string> ObterListaTiposVacina()
        {

            _listaTiposVacina = _listaTiposVacina ?? ObterListaString("TiposVacina").ToList();
            return _listaTiposVacina;

        }
        public static IEnumerable<string> ObterRacasCaes()
        {

            _listaRacasCaes = _listaRacasCaes ?? ObterListaString("RacasCaes").ToList();
            return _listaRacasCaes;

        }
        public static IEnumerable<string> ObterRacasGatos()
        {

            _listaRacasGatos = _listaRacasGatos ?? ObterListaString("RacasGatos").ToList();
            return _listaRacasGatos;

        }
        public static string ObterCaminhoLogo()
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.ArquivoLogo)) return null;
            return Path.Combine(ObterCaminhoExecucao(), Properties.Settings.Default.ArquivoLogo);
        }

        private static IEnumerable<string> ObterListaString(string nomeLista)
        {
            var config = Path.Combine(ObterCaminhoExecucao(), CONFIG_FILE);
            var x = XDocument.Load(config);
            return x.Root.Element(nomeLista).Elements()
                .Select(p => p.Attribute("Value").Value.ToString());

        }
        private static IEnumerable<KeyValuePair<int, string>> ObterListaKvp(string nomeLista)
        {
            var config = Path.Combine(ObterCaminhoExecucao(), CONFIG_FILE);
            var x = XDocument.Load(config);
            return x.Root.Element(nomeLista).Elements()
                .Select(p =>
                new KeyValuePair<int, string>(Convert.ToInt32(p.Attribute("Key").Value), p.Attribute("Value").Value.ToString()));

        }
       
        public static IEnumerable<KeyValuePair<int, string>> ObterListaTiposTelefone()
        {
            _tiposTelefones = _tiposTelefones ?? ObterListaKvp("TipoTelefones").ToList();
            return _tiposTelefones;
        }



        public static IEnumerable<KeyValuePair<int, string>> ObterListaGeneroAnimal()
        {
            _generoAnimal = _generoAnimal ?? ObterListaKvp("Sexo").ToList();
            return _generoAnimal;
        }




        public static IEnumerable<KeyValuePair<int, string>> ObterListaEspecieAnimal()
        {
             _especieAnimal = _especieAnimal ?? ObterListaKvp("Especies").ToList();
            return _especieAnimal;
           
        }

        public static IEnumerable<KeyValuePair<int, string>> ObterListaStatusAnimal()
        {

            _statusAnimal = _statusAnimal ?? ObterListaKvp("StatusAnimal").ToList();
            return _statusAnimal;
           
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaAmbientesAnimal()
        {
            _ambienteAnimal = _ambienteAnimal ?? ObterListaKvp("AmbienteAnimal").ToList();
            return _ambienteAnimal;
        }



        public static IEnumerable<KeyValuePair<int, string>> ObterListaStatusCaixaTransporte()
        {
            _statusCaixaTransporte = _statusCaixaTransporte ?? ObterListaKvp("StatusCaixaTransporte").ToList();
            return _statusCaixaTransporte;
           
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaSituacaoCaixaTransporte()
        {
            _situacaoCaixaTransporte = _situacaoCaixaTransporte ?? ObterListaKvp("SituacaoCaixaTransporte").ToList();
            return _situacaoCaixaTransporte;
          
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaLocalizacaoCaixaTransporte()
        {
            _localizacaoCaixaTransporte = _localizacaoCaixaTransporte ?? ObterListaKvp("LocalizacaoCaixaTransporte").ToList();
            return _localizacaoCaixaTransporte;
            
        }

        public static IEnumerable<KeyValuePair<int, string>> ObterListaPessoasCategoria()
        {
            _categorias = _categorias ?? ObterListaKvp("CategoriaSocios").ToList();
            return _categorias;
            
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaPessoasTipos()
        {
            _tiposPessoa = _tiposPessoa ?? ObterListaKvp("TipoSocios").ToList();
            return _tiposPessoa;
            
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaPessoasStatus()
        {
            _statusPessoas = _statusPessoas ?? ObterListaKvp("StatusPessoa").ToList();
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
        public static IEnumerable<KeyValuePair<int, string>> ObterListaNiveisUsuarios()
        {
            _niveisUsuario = _niveisUsuario ?? ObterListaKvp("NiveisUsuario").ToList();
            return _niveisUsuario;
        }


    }
}
