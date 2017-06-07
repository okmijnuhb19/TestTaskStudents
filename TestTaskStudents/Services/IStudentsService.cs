using System.Collections;
using System.Collections.Generic;
using TestTaskStudents.Models;

namespace TestTaskStudents.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> LoadStudents();

        IEnumerable<Student> DeleteStudents();

        int SaveStudents(IEnumerable<Student> students);

        IEnumerable<Student> EditStudent(Student student);
    }
}