using System;
using System.Globalization;
using System.Windows.Data;
using TestTaskStudents.Models;

namespace TestTaskStudents.Converters
{
    public class NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var student = (Student) value;
            if (string.IsNullOrWhiteSpace(student?.FirstName) || string.IsNullOrWhiteSpace(student.Last))
            {
                return string.Empty;
            }
            return $"{student.FirstName} {student.Last}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
