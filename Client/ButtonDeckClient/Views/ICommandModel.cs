using System.ComponentModel;
using System.Windows.Input;

namespace ButtonDeckClient.Views
{
    internal interface ICommandModel : INotifyPropertyChanged
    {
        ICommand Command { get; }

        void Update();
    }
}
