using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Nokia.Music.Types;


namespace NewForFaves.Converters
{
    public class NewsToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IEnumerable<Product> products = value as IEnumerable<Product>;
            string parString = (string)parameter;

            if (products.Count() > 0)
            {
                return (parString == "1") ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return (parString == "0") ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
