using System.Diagnostics;

namespace ButtonDeckClient.Views
{
    internal class EmptyCommandModel : CommandModel
    {
        protected override bool CanExecute()
        {
            return false;
        }

        protected override void Execute()
        {
            Debug.Assert(false, "Empty command was executed.");
        }
    }
}
