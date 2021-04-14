using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WptfTest.Converters
{
    public class MenuVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue.Equals(true))
            {
                return Visibility.Visible;
            }
            else
                return Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //bool boolValue = (bool)value;
            //if (boolValue.Equals(true))
            //{
            //    return 1;
            //}
            //else
            //    return 2;
            return null;
        }
    }
}
