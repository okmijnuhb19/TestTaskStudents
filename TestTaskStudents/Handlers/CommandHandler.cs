using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestTaskStudents.Handlers
{
    public class CommandHandler : ICommand
    {
        private readonly Action<object> action;
        private readonly bool canExecute;

        public CommandHandler(Action<object> action, bool canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter=null)
        {
            action(parameter);
        }
    }
}
