﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Amigo
{
    public class EnumToBooleanConverter : MarkupExtension, IValueConverter
    {
        // Convert enum [value] to boolean, true if matches [param]
        public object Convert(object value, Type targetType, object param, CultureInfo culture)
        {
            return value.Equals(param);
        }

        // Convert boolean to enum, returning [param] if true
        public object ConvertBack(object value, Type targetType, object param, CultureInfo culture)
        {
            return (bool)value ? param : Binding.DoNothing;
        }
        private EnumToBooleanConverter _converter;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {

            if (_converter == null)
            {
                _converter = new EnumToBooleanConverter();
            }

            return _converter;
        }

    }
}
