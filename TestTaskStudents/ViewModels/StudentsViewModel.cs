using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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
        private Student selectedStudent;
        private ICommand addStudentCommand;
        private ICommand deleteStudentCommand;
        private ICommand editStudentsCommand;

        public ICommand AddStudentCommand => addStudentCommand ??
                                             (addStudentCommand = new CommandHandler(AddStudent, true));

        public ICommand EditStudentCommand => editStudentsCommand ??
                                             (editStudentsCommand = new CommandHandler(EditStudent, true));

        public ICommand DeleteStudentCommand => deleteStudentCommand ??
                                             (deleteStudentCommand = new CommandHandler(DeleteStudent, true));

        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                NotifyPropertyChanged(nameof(SelectedStudent));
            }
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

        private void AddStudent(object parameter)
        {
            var newStudent = new Student { Id = -1 };
            new EditStudentView(new EditStudentViewModel(newStudent, this)).Show();
            CurrentWindow.Hide();
        }

        private void EditStudent(object parameter)
        {
            if (SelectedStudent == null)
            {
                return;
            }

            new EditStudentView(new EditStudentViewModel(SelectedStudent, this)).Show();
            CurrentWindow.Hide();
        }

        private void DeleteStudent(object parameter)
        {
            if (SelectedStudent == null)
            {
                return;
            }

            var result = MessageBox.Show("Do you want to delete this student?", "Confirmation",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            Students = studentsService.DeleteStudent(SelectedStudent).ToList();
        }


        public override void ViewAppear(object sender, EventArgs e)
        {
            base.ViewAppear(sender, e);
            Students = studentsService.LoadStudents().ToList();
            NotifyPropertyChanged(nameof(Students));
        }
    }
}
