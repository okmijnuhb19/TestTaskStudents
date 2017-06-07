using System;

namespace TestTaskStudents.Models
{
    [Serializable]
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Last { get; set; }

        public int Age { get; set; }

        public int Gender { get; set; }
    }
}