using System.Collections;
using System.Collections.Generic;
using TestTaskStudents.Models;

namespace TestTaskStudents.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> LoadStudents();

        IEnumerable<Student> DeleteStudents();

        void SaveStudents(IEnumerable<Student> students);

        void EditStudent(Student student);
    }
}