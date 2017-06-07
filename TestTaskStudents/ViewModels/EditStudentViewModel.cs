using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Autofac;
using ControlLib;
using TestTaskStudents.Handlers;
using TestTaskStudents.Models;
using TestTaskStudents.Services;
using TestTaskStudents.Views;

namespace TestTaskStudents.ViewModels
{
    public class EditStudentViewModel:BaseViewModel
    {
        private IStudentsService studentsService;
        private Student student;
        private string firstName;
        private string lastName;
        private int age;
        private GenderType gender;

        private ICommand saveCommand;
        private ICommand canselCommand;
        private BaseViewModel previousViewModel;

        public ICommand SaveCommand => saveCommand ??
                                             (saveCommand = new CommandHandler(Save, true));

        public ICommand CancelCommand => canselCommand ??
                                       (canselCommand = new CommandHandler(Cancel, true));

        private void Cancel(object obj)
        {
            NavigateToMainWindow();
        }

        private void Save(object obj)
        {
            student.FirstName = FirstName;
            student.Last = LastName;
            student.Age = Age;
            student.Gender = (int)Gender;
            studentsService.EditStudent(student);
            NavigateToMainWindow();
        }

        private void NavigateToMainWindow()
        {
            previousViewModel.ViewAppear(previousViewModel.CurrentWindow,EventArgs.Empty);
            previousViewModel.CurrentWindow.Show();
            CurrentWindow.Close();
        }

        public string FirstName {
            get => firstName;
            set
            {
                firstName = value;
                NotifyPropertyChanged(nameof(FirstName));
            }}

        public string LastName {
            get => lastName;
            set
            {
                lastName = value;
                NotifyPropertyChanged(nameof(LastName));
            }}

        public int Age
        {
            get => age;
            set
            {
                age = value;
                NotifyPropertyChanged(nameof(Age));
            }
        }
        public GenderType Gender
        {
            get => gender;
            set
            {
                gender = value;
                NotifyPropertyChanged(nameof(GenderType));
            }
        }

        public ValueChangedEventHandler ValueChanged;

        public List<GenderType> Genders => Enum.GetValues(typeof(GenderType)).Cast<GenderType>().ToList();

        public EditStudentViewModel(Student student, BaseViewModel previousViewModel)
        {
            studentsService = App.Container.Resolve<IStudentsService>();
            Initialize(student, previousViewModel);
        }

        private void Initialize(Student student, BaseViewModel previousViewModel)
        {
            this.student = student;
            this.previousViewModel = previousViewModel;
            firstName = student.FirstName;
            lastName = student.Last;
            age = student.Age < 16 ? 16 : student.Age;
            gender = (GenderType) student.Gender;
            ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            Age = (int) e.NewValue;
        }
    }
}
