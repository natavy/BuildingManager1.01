using Building.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Building.Manager.Controls.Schedule
{
    public class DeleteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<Task>_action;

        public DeleteCommand(Action<Task>action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = parameter as Task;
            _action(viewModel);
        }
    }
}
