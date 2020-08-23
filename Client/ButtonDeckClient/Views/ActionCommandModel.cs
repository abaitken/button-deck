using System;

namespace ButtonDeckClient.Views
{
    class ActionCommandModel : CommandModel
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;

        public ActionCommandModel(Func<bool> canExecute, Action execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        protected override bool CanExecute()
        {
            return _canExecute();
        }

        protected override void Execute()
        {
            _execute();
        }
    }
}
