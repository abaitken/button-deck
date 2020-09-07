﻿using ButtonDeckClient.Arduino;
using ButtonDeckClient.Logging;
using ButtonDeckClient.Views.ButtonDeckTest;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.Views.Main
{
    class MainViewModel : PropertyChangedViewModel
    {
        public ViewModelProperty<IEnumerable<string>> SerialPorts { get; private set; }
        public ReadOnlyViewModelProperty<List<SerialPortMenuItem>> SerialPortMenuItems { get; private set; }
        public ViewModelProperty<string> CurrentSerialPort { get; private set; }
        private SerialMonitor SerialMonitor { get; }
        private ISettings Settings => Properties.Settings.Default;
        public ICommandModel TestButtonDeckCommand { get; }
        public LogListener LogListener { get; }
        private ILogger RootLogger { get; }
        private ButtonDeckCommunication Communication { get; }
        private ActionRouter ActionRouter { get; set; }

        public MainViewModel()
        {
            CurrentSerialPort = new ViewModelProperty<string>(ConnectToArduino);
            SerialPorts = new ViewModelProperty<IEnumerable<string>>();
            SerialPortMenuItems = new ReadOnlyViewModelProperty<List<SerialPortMenuItem>>(SerialPorts, () =>
            {
                var items = new List<SerialPortMenuItem>();
                if(SerialPorts.Value != null)
                    foreach (var item in SerialPorts.Value)
                        items.Add(new SerialPortSelectionItem(this, item));

                if (items.Count == 0)
                    items.Add(NoPortsAvailable.Value);

                return items;
            });
            SerialMonitor = new SerialMonitor();
            TestButtonDeckCommand = new ActionCommandModel(() => !string.IsNullOrEmpty(CurrentSerialPort.Value), OnTestButtonDeck);

            LogListener = new LogListener();
            RootLogger = new LoggerFactory().Create(LogListener);
            Communication = new ButtonDeckCommunication(RootLogger);
        }

        private void OnTestButtonDeck()
        {
            if (string.IsNullOrWhiteSpace(CurrentSerialPort.Value))
                return;
            
            ActionRouter = null;
            var window = new ButtonDeckTestWindow();
            window.ViewModel.Connect(Communication);
            window.ShowDialog();
            HandleActions();
        }

        internal void Closed()
        {
            Settings.Save();
        }

        internal void Closing(System.ComponentModel.CancelEventArgs e)
        {
        }

        private void ConnectToArduino()
        {
            if (Communication.IsConnected)
                Communication.Disconnect();

            Communication.Connect(CurrentSerialPort.Value);
            Settings.PreviousCOMPort = CurrentSerialPort.Value;
            TestButtonDeckCommand?.Update();
        }

        public void LoadedOnce()
        {
            // TODO : Detect if previously crashed, if so, ask to reset all settings
            SerialPorts.Value = SerialMonitor.PortNames;

            // TODO : Report if connection cannot be made
            if (SerialPorts.Value.Contains(Settings.PreviousCOMPort))
                CurrentSerialPort.Value = Settings.PreviousCOMPort;

            HandleActions();
        }

        private void HandleActions()
        {
            ActionRouter = new ActionRouter(RootLogger, Communication);
        }
    }
}
