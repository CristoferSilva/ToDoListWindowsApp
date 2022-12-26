using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFToDoList.Model.Commands
{
    public class RelayCommand : ICommand
    {
        public Action action;
        public Predicate<object> predicate;

        public RelayCommand(Action action, Predicate<object> predicate)
        {
            if (action == null)
                throw new NullReferenceException("execute");

            this.action = action;
            this.predicate = predicate;
        }

        public RelayCommand(Action action) : this(action, null) { }

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
            action.Invoke();
        }
    }
}
