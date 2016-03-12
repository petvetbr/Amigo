using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Amigo
{
    [ValueConversion(typeof(int), typeof(string))]
    class NumeroParaNomeMesConverter : MarkupExtension, IValueConverter
    {
        private NumeroParaNomeMesConverter _converter;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valor = value as int?;
            if (valor == null) return value;
            return new DateTime(2000, valor.Value, 1).ToString("MMM");


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {

            if (_converter == null)
            {
                _converter = new NumeroParaNomeMesConverter();
            }

            return _converter;
        }
     
    }
}
