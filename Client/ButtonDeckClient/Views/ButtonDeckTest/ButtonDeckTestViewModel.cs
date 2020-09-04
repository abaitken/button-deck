using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.Views.ButtonDeckTest
{
    class ButtonDeckTestViewModel : PropertyChangedViewModel
    {
        public ButtonDeckTestViewModel()
        {
            Messages = new ObservableCollection<string>();
        }

        internal void LoadedOnce()
        {
        }

        internal void Connect(string portName)
        {
        }

        public ObservableCollection<string> Messages { get; }
    }
}
