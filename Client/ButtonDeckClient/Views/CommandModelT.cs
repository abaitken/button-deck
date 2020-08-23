using System;
using System.Windows.Input;

namespace ButtonDeckClient.Views
{
    internal abstract class CommandModel<T> : PropertyChangedViewModel, ICommandModel, ICommand
    {
        public ICommand Command => this;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        protected abstract bool CanExecute(T parameter);

        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }

        protected abstract void Execute(T parameter);

        public void Update()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
