using ButtonDeckClient.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.Arduino
{
    public interface IButtonDeckCommunication
    {
        event EventHandler<ButtonEventArgs> ButtonDown;
        event EventHandler<ButtonEventArgs> ButtonUp;
        event EventHandler<ToggleStateChangeEventArgs> ToggleStateChanged;
        event EventHandler<LEDBrightnessEventArgs> LEDBrightness;
        event EventHandler<VersionEventArgs> VersionResponse;
        event EventHandler<HeartbeatEventArgs> HeartbeatResponse;
        event EventHandler InvalidResponse;
        event EventHandler AcknowledgedResponse;

        void SetLedColor(int index, RGB color);
    }

    class ButtonDeckCommunication : IButtonDeckCommunication
    {
        private readonly ILogger _logger;
        private SerialConnection _connection;

        public ButtonDeckCommunication(ILogger logger)
        {
            _logger = logger;
            MessageHandler = new MessageHandler(logger);
            MessageBuilder = new MessageBuilder(logger);
        }

        public bool IsConnected => _connection != null;

        private SerialConnection Connection
        {
            get
            {
                if (!IsConnected)
                    throw new InvalidOperationException("No connection has been set");

                return _connection;
            }

            set
            {
                if(IsConnected)
                    throw new InvalidOperationException("Connection has already been set");

                _connection = value;
            }
        }

        public void Connect(string portName)
        {
            Connection = new SerialConnection(_logger, portName, MessageHandler);
            Connection.Open();
        }

        public void Disconnect()
        {
            Connection.Close();
            Connection.Dispose();
            Connection = null;
        }

        private MessageBuilder MessageBuilder { get; }
        private MessageHandler MessageHandler { get; }

        public event EventHandler<ButtonEventArgs> ButtonDown
        {
            add { MessageHandler.ButtonDown += value; }
            remove { MessageHandler.ButtonDown -= value; }
        }

        public event EventHandler<ButtonEventArgs> ButtonUp
        {
            add { MessageHandler.ButtonUp += value; }
            remove { MessageHandler.ButtonUp -= value; }
        }

        public event EventHandler<ToggleStateChangeEventArgs> ToggleStateChanged
        {
            add { MessageHandler.ToggleStateChanged += value; }
            remove { MessageHandler.ToggleStateChanged -= value; }
        }

        public event EventHandler<LEDBrightnessEventArgs> LEDBrightness
        {
            add { MessageHandler.LEDBrightness += value; }
            remove { MessageHandler.LEDBrightness -= value; }
        }

        public event EventHandler<VersionEventArgs> VersionResponse
        {
            add { MessageHandler.VersionResponse += value; }
            remove { MessageHandler.VersionResponse -= value; }
        }

        public event EventHandler<HeartbeatEventArgs> HeartbeatResponse
        {
            add { MessageHandler.HeartbeatResponse += value; }
            remove { MessageHandler.HeartbeatResponse -= value; }
        }

        public event EventHandler InvalidResponse
        {
            add { MessageHandler.InvalidResponse += value; }
            remove { MessageHandler.InvalidResponse -= value; }
        }

        public event EventHandler AcknowledgedResponse
        {
            add { MessageHandler.AcknowledgedResponse += value; }
            remove { MessageHandler.AcknowledgedResponse -= value; }
        }


        public void RequestToggleState(int toggleIndex)
        {
            Connection.Send(MessageBuilder.GetToggleState(toggleIndex.ToByte()));
        }

        public void RequestLedBrightness()
        {
            Connection.Send(MessageBuilder.GetLedBrightness());
        }

        public void SetLedBrightness(int brightness)
        {
            Connection.Send(MessageBuilder.SetLedBrightness(brightness.ToByte()));
        }

        public void RequestVersion()
        {
            Connection.Send(MessageBuilder.GetVersion());
        }

        public void Heartbeat(int number)
        {
            Connection.Send(MessageBuilder.Heartbeat(number.ToByte()));
        }

        public void SetLedColor(int index, RGB color)
        {
            Connection.Send(MessageBuilder.SetLedColor(index.ToByte(), color));
        }

        public void SetLedColors(IEnumerable<Tuple<int, RGB>> items)
        {
            var indexes = items.Select(i => i.Item1.ToByte()).ToArray();
            var colors = items.Select(i => i.Item2).ToArray();
            Connection.Send(MessageBuilder.SetManyLedColor(indexes, colors));
        }
    }
}
