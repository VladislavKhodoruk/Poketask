using System.Globalization;

namespace Poketask.Entities
{
    public class CapitalizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value.ToString().ToUpper()[0]}{value.ToString().Substring(1)}";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           return value.ToString().ToLower();
        }
    }

    public class AddFileExtension : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value}.{parameter}";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Substring(0, value.ToString().IndexOf('.'));
        }
    }
}
