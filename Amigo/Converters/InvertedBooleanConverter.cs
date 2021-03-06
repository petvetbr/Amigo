﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Amigo
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter : MarkupExtension, IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {

            if (value == null) return null;
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {

            if (value == null) return null;
            return !(bool)value;
        }

        private InverseBooleanConverter _converter;
        public override object  ProvideValue(IServiceProvider serviceProvider)
        {

            if (_converter == null)
            {
                _converter = new InverseBooleanConverter();
            }

            return _converter;
        }

        #endregion
    }

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class InverseBooleanVisibilityConverter : MarkupExtension, IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {

            if (value == null) return Visibility.Collapsed;
            return ((bool)value)?Visibility.Collapsed:Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {

            throw new NotImplementedException();
        }

        private InverseBooleanVisibilityConverter _converter;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {

            if (_converter == null)
            {
                _converter = new InverseBooleanVisibilityConverter();
            }

            return _converter;
        }

        #endregion
    }
}
