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
