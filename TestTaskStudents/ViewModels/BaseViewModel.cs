using System;
using System.ComponentModel;
using System.Windows;

namespace TestTaskStudents.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public virtual void ViewAppear(object sender, EventArgs e)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Window CurrentWindow { get; set; }

        protected void NotifyPropertyChanged(
            string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
