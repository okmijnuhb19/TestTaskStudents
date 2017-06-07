using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TestTaskStudents.Models;

namespace TestTaskStudents.Services
{
    public class StudentsService :IStudentsService
    {
        private readonly XmlSerializer serializer;
        public StudentsService()
        {
            serializer= new XmlSerializer(typeof(Student[]));
        }

        public IEnumerable<Student> LoadStudents()
        {
            using (var fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {
                var students = serializer.Deserialize(fs);
                return (List<Student>)students;
            }
        }

        public IEnumerable<Student> DeleteStudents()
        {
            throw new System.NotImplementedException();
        }

        public int SaveStudents(IEnumerable<Student> students)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> EditStudent(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}