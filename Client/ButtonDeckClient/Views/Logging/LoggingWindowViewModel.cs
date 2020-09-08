using ButtonDeckClient.Logging;
using System.Collections.ObjectModel;

namespace ButtonDeckClient.Views.Logging
{
    internal class LoggingWindowViewModel
    {
        public LoggingWindowViewModel()
        {
            Messages = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Messages { get; }

        public void Subscribe(LogListener listener)
        {
            listener.NewLine += Listener_NewLine;
        }

        private void Listener_NewLine(object sender, LogEventArgs e)
        {
            Messages.Add(e.Message);
        }
    }
}