﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.SerialComm
{
    public class CommandReceiver : IDisposable
    {
        public CommandReceiver(string portName)
        {
            _serialPort = new SerialPort
            {
                PortName = portName,
                BaudRate = 9600
            };
            _serialPort.DataReceived += _serialPort_DataReceived;
            _serialPort.Open();

        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // TODO
            //var x = _serialPort.ReadExisting();?
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls
        private readonly SerialPort _serialPort;

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
