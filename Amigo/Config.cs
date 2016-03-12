using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo
{
    public static class Config
    {

        private static IEnumerable<KeyValuePair<int, string>> _categorias;
        private static IEnumerable<KeyValuePair<int, string>> _statusPessoas;
        private static IEnumerable<KeyValuePair<int, string>> _tiposPessoa;
        private static IEnumerable<KeyValuePair<int, string>> _meses;
        private static IEnumerable<KeyValuePair<int, string>> _anos;
        private static IEnumerable<KeyValuePair<int, string>> _statusCaixaTransporte;
        private static IEnumerable<KeyValuePair<int, string>> _situacaoCaixaTransporte;
        private static IEnumerable<KeyValuePair<int, string>> _localizacaoCaixaTransporte;

        private static IEnumerable<KeyValuePair<int, string>> _ambienteAnimal;
        private static IEnumerable<KeyValuePair<int, string>> _statusAnimal;
        private static IEnumerable<KeyValuePair<int, string>> _especieAnimal;
        private static IEnumerable<KeyValuePair<int, string>> _generoAnimal;
        private static IEnumerable<KeyValuePair<int, string>> _tiposTelefones;
        private static IEnumerable<string>_listaUf;


        public static IEnumerable<string> ObterListaUf()
        {
            var _uf = new List<string>();
            _uf.Add("AC");
            _uf.Add("AL");
            _uf.Add("AP");
            _uf.Add("AM");
            _uf.Add("BA");
            _uf.Add("CE");
            _uf.Add("DF");
            _uf.Add("ES");
            _uf.Add("GO");
            _uf.Add("MA");
            _uf.Add("MT");
            _uf.Add("MS");
            _uf.Add("MG");
            _uf.Add("PA");
            _uf.Add("PB");
            _uf.Add("PR");
            _uf.Add("PE");
            _uf.Add("PI");
            _uf.Add("RJ");
            _uf.Add("RN");
            _uf.Add("RS");
            _uf.Add("RO");
            _uf.Add("RR");
            _uf.Add("SC");
            _uf.Add("SP");
            _uf.Add("SE");
            _uf.Add("TO");
            _listaUf = _uf;
            return _listaUf;
        }

       public static IEnumerable<KeyValuePair<int, string>> ObterListaTiposTelefone()
        {
            if (_tiposTelefones != null)
            {
                return _tiposTelefones;
            }
            var tel = new List<KeyValuePair<int, string>>();
            tel.Add(new KeyValuePair<int, string>(1, "Celular"));
            tel.Add(new KeyValuePair<int, string>(2, "Fixo"));
            tel.Add(new KeyValuePair<int, string>(2, "Recado"));
            _tiposTelefones = tel;
            return tel;
        }



        public static IEnumerable<KeyValuePair<int, string>> ObterListaGeneroAnimal()
        {
            if (_generoAnimal != null)
            {
                return _generoAnimal;
            }
            var sexo = new List<KeyValuePair<int, string>>();
            sexo.Add(new KeyValuePair<int, string>(1, "Macho"));
            sexo.Add(new KeyValuePair<int, string>(2, "Fêmea"));
            _generoAnimal = sexo;
            return sexo;
        }




        public static IEnumerable<KeyValuePair<int, string>> ObterListaEspecieAnimal()
        {
            if (_especieAnimal != null)
            {
                return _especieAnimal;
            }
            var especie = new List<KeyValuePair<int, string>>();
            especie.Add(new KeyValuePair<int, string>(1, "Canino"));
            especie.Add(new KeyValuePair<int, string>(2, "Felino"));
            _especieAnimal = especie;
            return especie;
        }

        public static IEnumerable<KeyValuePair<int, string>> ObterListaStatusAnimal()
        {
            if (_statusAnimal != null)
            {
                return _statusAnimal;
            }
            var status = new List<KeyValuePair<int, string>>();
            status.Add(new KeyValuePair<int, string>(1, "Normal"));
            status.Add(new KeyValuePair<int, string>(2, "Restricao ou problemas"));
            status.Add(new KeyValuePair<int, string>(3, "Morto"));
            _statusAnimal = status;
            return status;
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaAmbientesAnimal()
        {
            if (_ambienteAnimal != null)
            {
                return _ambienteAnimal;
            }
            var ambiente = new List<KeyValuePair<int, string>>();
            ambiente.Add(new KeyValuePair<int, string>(1, "Doméstico"));
            ambiente.Add(new KeyValuePair<int, string>(2, "De Rua"));
            _ambienteAnimal = ambiente;
            return ambiente;
        }



        public static IEnumerable<KeyValuePair<int, string>> ObterListaStatusCaixaTransporte()
        {
            if (_statusCaixaTransporte != null)
            {
                return _statusCaixaTransporte;
            }
            var status = new List<KeyValuePair<int, string>>();
            status.Add(new KeyValuePair<int, string>(1, "Disponivel"));
            status.Add(new KeyValuePair<int, string>(2, "Reservada"));
            _statusCaixaTransporte = status;
            return status;
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaSituacaoCaixaTransporte()
        {
            if (_situacaoCaixaTransporte != null)
            {
                return _situacaoCaixaTransporte;
            }
            var status = new List<KeyValuePair<int, string>>();
            status.Add(new KeyValuePair<int, string>(1, "Confirmada"));
            status.Add(new KeyValuePair<int, string>(2, "Pendente"));
            _situacaoCaixaTransporte = status;
            return status;
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaLocalizacaoCaixaTransporte()
        {
            if (_situacaoCaixaTransporte != null)
            {
                return _situacaoCaixaTransporte;
            }
            var local = new List<KeyValuePair<int, string>>();
            local.Add(new KeyValuePair<int, string>(1, "Depósito"));
            local.Add(new KeyValuePair<int, string>(2, "Emprestada"));
            local.Add(new KeyValuePair<int, string>(3, "Não devolvida"));
            _localizacaoCaixaTransporte = local;
            return _localizacaoCaixaTransporte;
        }

        public static IEnumerable<KeyValuePair<int,string>> ObterListaPessoasCategoria()
        {
            if(_categorias!=null)
            {
                return _categorias;
            }
            var cat = new List<KeyValuePair<int, string>>();
            cat.Add(new KeyValuePair<int, string>(1, "Fundador"));
            cat.Add(new KeyValuePair<int, string>(2, "Efetivo"));
            cat.Add(new KeyValuePair<int, string>(3, "Colaborador"));
            cat.Add(new KeyValuePair<int, string>(4, "Honorario"));
            cat.Add(new KeyValuePair<int, string>(5, "Mirim"));
            _categorias = cat.ToList();
            return cat;
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaPessoasTipos()
        {
            if(_tiposPessoa != null)
            {
                return _tiposPessoa;
            }
            var tipos = new List<KeyValuePair<int, string>>();
            tipos.Add(new KeyValuePair<int, string>(1, "Normal"));
            tipos.Add(new KeyValuePair<int, string>(2, "Diretoria"));
            tipos.Add(new KeyValuePair<int, string>(3, "Voluntário"));
            _tiposPessoa = tipos;
            return _tiposPessoa;
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaPessoasStatus()
        {
            if (_tiposPessoa != null)
            {
                return _tiposPessoa;
            }
            var status = new List<KeyValuePair<int, string>>();
            status.Add(new KeyValuePair<int, string>(1, "Ativo"));
            status.Add(new KeyValuePair<int, string>(2, "Pendente"));
            status.Add(new KeyValuePair<int, string>(3, "Inativo"));
            _statusPessoas = status;
            return status;
        }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaMeses()
        {
            if(_meses!=null)
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
