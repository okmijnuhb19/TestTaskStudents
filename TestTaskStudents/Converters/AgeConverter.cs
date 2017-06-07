using System;
using System.Globalization;
using System.Windows.Data;

namespace TestTaskStudents.Converters
{
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var age = (int?) value;
            if (!age.HasValue)
            {
                return string.Empty;
            }
            var postfix = age % 10 == 0 || age % 10 > 4 ? "лет" : "год(а)";
            return $"{age} {postfix}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}