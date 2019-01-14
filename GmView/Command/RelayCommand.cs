using System;
using System.Windows.Input;

namespace GmView.Command
{
    public class RelayCommand : ICommand
    {
        public Action ExecuteAction { get; private set; }
        public Predicate<object> CanExecuteAction { get; private set; }

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Predicate<object> canExecute = null)
        {
            ExecuteAction = execute;
            CanExecuteAction = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if(CanExecuteAction != null)
            {
                return CanExecuteAction(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            ExecuteAction();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class RelayCommand<T> : ICommand where T : class
    {
        public Action<T> _execute;
        public Predicate<T> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if(_canExecute != null)
            {
                return _canExecute(parameter as T);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter as T);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}