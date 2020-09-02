using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.Arduino
{
    class SerialMonitor
    {
        public string[] PortNames => SerialPort.GetPortNames();

        // TODO : Raise event when new ports are added
        // TODO : Raise event when ports are removed
        // Suggested reading: 
        // https://stackoverflow.com/questions/4199083/detect-serial-port-insertion-removal
    }
}
