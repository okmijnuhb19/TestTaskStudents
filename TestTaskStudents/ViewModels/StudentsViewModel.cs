using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TestTaskStudents.Services;

namespace TestTaskStudents.ViewModels
{
    public class StudentsViewModel: BaseViewModel
    {
        public StudentsViewModel()
        {
            var students=App.Container.Resolve<IStudentsService>().LoadStudents();

        }
    }
}
