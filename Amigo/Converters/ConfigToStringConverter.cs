using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Amigo.Converters
{
    public class ConfigToStringConverter:MarkupExtension, IValueConverter
    {
        
        public object Convert(object value, Type targetType, object param, CultureInfo culture)
        {
            var valor = value as int?;
            var parametro = param as string;
            if (valor == null || param == null) return string.Empty;
            switch (parametro)
            {
                case "PessoasStatus":
                    {
                        return Config.ObterListaPessoasStatus().SingleOrDefault(p => p.Key == valor.Value);
                    }
                default:
                    break;
            }
            return string.Empty;
            
        }

        // Convert boolean to enum, returning [param] if true
        public object ConvertBack(object value, Type targetType, object param, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        private ConfigToStringConverter _converter;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {

            if (_converter == null)
            {
                _converter = new ConfigToStringConverter();
            }

            return _converter;
        }

    }
}
