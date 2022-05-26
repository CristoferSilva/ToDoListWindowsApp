using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ToDoListWPF.Commands
{
    public class RelayCommand : ICommand
    {
        public Action<object> action;
        public Predicate<object> predicate;

        public RelayCommand(Action<object> action, Predicate<object> predicate)
        {
            if (action == null)
                throw new NullReferenceException("execute");

            this.action = action;
            this.predicate = predicate;
        }

        public RelayCommand(Action<object> action) : this(action, null) { }

        public bool CanExecute(object parameter)
        {
            return action != null;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            action.Invoke(parameter);
        }
    }
}
