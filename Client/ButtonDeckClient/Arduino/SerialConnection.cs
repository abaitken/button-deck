using ButtonDeckClient.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ButtonDeckClient.Arduino
{
    internal class SerialConnection
    {
        private readonly SerialPort _serialPort;
        private readonly ILogger _logger;
        private readonly MessageHandler _messageHandler;

        public SerialConnection(ILogger logger, string portName, MessageHandler messageHandler)
        {
            _serialPort = new SerialPort
            {
                PortName = portName,
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Encoding = Encoding.ASCII
            };
            _logger = CategoryLogger.Create(nameof(SerialConnection), logger);
            _messageHandler = messageHandler;
        }

        public void Open()
        {
            _logger.WriteLine($"Connecting to serial port '{_serialPort.PortName}' at baud rate '{_serialPort.BaudRate}'");
            _serialPort.Open(); // TODO : Handle errors
            _logger.WriteLine($"Connected.");
            BeginRead();
        }

        private void BeginRead()
        {
            Task.Factory.StartNew(() =>
            {
                _serialPort.ReadTimeout = int.MaxValue - 1;
                while (_serialPort.IsOpen)
                {
                    try
                    {
                        _messageHandler.ProcessMessage(_serialPort.BaseStream);
                    }
                    catch (IOException e)
                    {
                    }
                    Thread.Sleep(1);
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Close()
        {
            _serialPort.Close();
        }

        public void Send(byte[] data)
        {
            _serialPort.Write(data, 0, data.Length);
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _serialPort.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CommandReceiver() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
