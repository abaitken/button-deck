using System;

namespace ButtonDeckClient.Views
{
    internal class ActionCommandModel<T> : CommandModel<T>
    {
        private readonly Func<T, bool> _canExecute;
        private readonly Action<T> _execute;

        public ActionCommandModel(Func<T, bool> canExecute, Action<T> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        protected override bool CanExecute(T parameter)
        {
            return _canExecute(parameter);
        }

        protected override void Execute(T parameter)
        {
            _execute(parameter);
        }
    }
}
