using System;
using System.Windows.Input;

namespace ButtonDeckClient.Views
{
    internal abstract class CommandModel : PropertyChangedViewModel, ICommandModel, ICommand
    {
        public ICommand Command => this;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        protected abstract bool CanExecute();


        public void Execute(object parameter)
        {
            Execute();
        }

        protected abstract void Execute();

        public void Update()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
