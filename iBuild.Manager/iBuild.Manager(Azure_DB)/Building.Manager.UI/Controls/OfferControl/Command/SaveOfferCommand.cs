using Building.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Building.Manager.Controls
{
    public class SaveOfferCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<Offer> _action;

        public SaveOfferCommand(Action<Offer> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = parameter as Offer;
            _action(viewModel);
        }
    }
}
