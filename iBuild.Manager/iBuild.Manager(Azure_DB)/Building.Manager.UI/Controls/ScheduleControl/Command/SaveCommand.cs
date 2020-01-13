using System;
using System.Windows.Input;
using Building.Manager.Model;

namespace Building.Manager.Controls.Schedule
{
    public class SaveCommand : ICommand
    {
        private readonly Action<Task> _action;
        public SaveCommand(Action<Task> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var viewModel = parameter as Task;
            _action(viewModel);
        }

    }
}
