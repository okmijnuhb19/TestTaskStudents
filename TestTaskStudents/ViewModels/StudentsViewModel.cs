using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Autofac;
using TestTaskStudents.Handlers;
using TestTaskStudents.Models;
using TestTaskStudents.Services;
using TestTaskStudents.Views;

namespace TestTaskStudents.ViewModels
{
    public class StudentsViewModel: BaseViewModel
    {
        private readonly IStudentsService studentsService;

        private List<Student> students;
        private ICommand addStudentCommand;
        private ICommand deleteStudentsCommand;

        public ICommand AddStudentCommand => addStudentCommand ??
                                             (addStudentCommand = new CommandHandler(AddStudent, true));
        

        public ICommand DeleteStudentCommand => deleteStudentsCommand ??
                                             (deleteStudentsCommand = new CommandHandler(DeleteStudents, true));

        private void AddStudent(object parameter)
        {
            new EditStudentView(new EditStudentViewModel((Student)parameter ?? new Student(),this)).Show();
            CurrentWindow.Hide();
            
        }

        private void DeleteStudents(object parameter)
        {

        }

        public List<Student> Students
        {
            get => students;
            set
            {
                students = value;
                NotifyPropertyChanged(nameof(Students));
            }
        }

        public StudentsViewModel()
        {
            studentsService = App.Container.Resolve<IStudentsService>();

        }

        public override void ViewAppear(object sender, EventArgs e)
        {
            base.ViewAppear(sender, e);
            Students = studentsService.LoadStudents().ToList();
            NotifyPropertyChanged(nameof(Students));
        }
    }
}
