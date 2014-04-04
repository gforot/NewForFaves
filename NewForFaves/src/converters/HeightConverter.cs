using System;
using System.Globalization;
using System.Windows.Data;
using Cimbalino.Phone.Toolkit.Extensions;


namespace NewForFaves.Converters
{
    public class HeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is object[])
            {
                object[] values = value as object[];
                double rval = 0;
                foreach (object o in values)
                {
                    if (o is double)
                    {
                        rval += (double)o;
                    }
                    else if (o is int)
                    {
                        rval += (int)o;
                    }
                    else if (o is string)
                    {
                        int tmp;
                        if (int.TryParse(o as string, out tmp))
                        {
                            rval += tmp;
                        }
                    }
                    else
                    {
                        
                    }
                }
                return rval;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
