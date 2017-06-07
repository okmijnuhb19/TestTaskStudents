using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using TestTaskStudents.Models;

namespace TestTaskStudents.Services
{
    public class StudentsService : IStudentsService
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
                var students = (Student[])serializer.Deserialize(fs);
                return students.ToList();
            }
        }

        public IEnumerable<Student> DeleteStudents()
        {
            throw new System.NotImplementedException();
        }

        public void SaveStudents(IEnumerable<Student> students)
        {
            using (var fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs,students.ToArray());
            }
        }

        public void EditStudent(Student student)
        {
            var students = LoadStudents().ToList();
            if (student.Id == null)
            {
                student.Id = students.LastOrDefault()?.Id + 1;
                students.Add(student);
                SaveStudents(students);
            }
            else
            {
                students.Remove(students.FirstOrDefault(s => s.Id == student.Id));
                students.Add(student);
                SaveStudents(students.OrderBy(s => s.Id).ToList());
            }
        }
    }
}