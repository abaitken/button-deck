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

        }

        private void ConnectToArduino()
        {
            // TODO : Disconnect from previous?
            // TODO : Connect to new
        }

        public void LoadedOnce()
        {
            SerialPorts.Value = SerialPort.GetPortNames();
            // TODO : Get previous COM port and connect to it
        }
    }
}
