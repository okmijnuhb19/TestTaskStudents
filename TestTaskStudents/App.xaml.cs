using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using TestTaskStudents.Services;
using TestTaskStudents.ViewModels;
using TestTaskStudents.Views;

namespace TestTaskStudents
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            SetUpContainer();
            var studentsView = new StudentsView(new StudentsViewModel());
            studentsView.Show();
        }

        private static void SetUpContainer()
        {
            var builder = new ContainerBuilder();
            BuildupContainer(builder);
            Container = builder.Build();
        }

        private static void BuildupContainer(ContainerBuilder builder)
        {
            builder.RegisterType<StudentsService>().As<IStudentsService>();
        }
    }
}
