using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BryanPorter.PasswordManager.WpfUi
{
    public class SimpleCommand<T>
        : ICommand
    {
        private Action<T> _executeAction = null;

        public bool CanExecute(object parameter)
        {
            return ExecuteAction != null;
        }

        protected virtual void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;

        public Action<T> ExecuteAction
        {
            get { return _executeAction; }
            set
            {
                if (value != _executeAction)
                {
                    _executeAction = value;
                    OnCanExecuteChanged();
                }
            }
        }

        public void Execute(object parameter)
        {
            if (ExecuteAction != null)
            {
                ExecuteAction((T)parameter);
            }
        }
    }
}
