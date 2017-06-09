using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTaskStudents
{
    public static class EnumExtensions
    {
        public static List<object> Values(this Enum theEnum)
        {
            return Enum.GetValues(theEnum.GetType()).Cast<object>().ToList();
        }
    }
}