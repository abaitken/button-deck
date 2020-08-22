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
        public ViewModelProperty<string> CurrentSerialPort { get; private set; }

        public void LoadedOnce()
        {
            CurrentSerialPort = new ViewModelProperty<string>();
            //SerialPorts = new ViewModelProperty<IEnumerable<string>>
            //{
            //    Value = SerialPort.GetPortNames()
            //};
            SerialPorts = new ViewModelProperty<IEnumerable<string>>
            {
                Value = new[] {"COM4", "COM5"}
            };
        }

    }
}
