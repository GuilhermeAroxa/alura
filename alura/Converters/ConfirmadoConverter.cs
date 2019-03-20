using System;
using System.Globalization;
using Xamarin.Forms;

namespace alura.Converters
{
    public class ConfirmadoConverter : IValueConverter
    {
        public ConfirmadoConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Color.Green;
            }
            else
            {
                return Color.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
