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
                try
                {
                    var s = serializer.Deserialize(fs);
                    var students = (Student[]) s;
                    return students.ToList();
                }
                catch (Exception)
                {
                    return new List<Student>();
                }
            }
        }

        public IEnumerable<Student> DeleteStudent(Student student)
        {
            var students = LoadStudents().ToList();
            students.Remove(students.FirstOrDefault(s => s.Id == student.Id));
            SaveStudents(students);
            return students;
        }
        
        public void SaveStudents(IEnumerable<Student> students)
        {
            File.WriteAllText("Students.xml", string.Empty);
            using (var fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs,students.ToArray());
            }
        }

        public void EditStudent(Student student)
        {
            var students = LoadStudents().ToList();
            if (student.Id < 0)
            {
                student.Id = students.Any() ? (int) students.LastOrDefault()?.Id + 1 : 0;
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