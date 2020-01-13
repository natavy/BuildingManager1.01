using Building.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Building.Manager.Controls.ServiceControl
{
    public class UpdateServiceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<Service> _action;

        public UpdateServiceCommand(Action<Service> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = parameter as Service;
            _action(viewModel);
        }
    }
}
