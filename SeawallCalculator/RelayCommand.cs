using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SeawallCalculator
{
    //RelayCommand implements the ICommand interface and can be used for any control in the views.
    //From documentation: ICommand provides the commanding behavior for UI elements 
    class RelayCommand:ICommand
    {
        //Represents a specialized action that can be executed on an item 
        private Action<object> _action;
        public RelayCommand(Action<object> action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute (object parameter)
        {
            if (parameter != null)
            {
                _action(parameter);
            }
            else
            {
                _action("Hello World");
            }
        }
    }
}
