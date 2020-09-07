using ButtonDeckClient.Logging;
using System;
using System.IO;

namespace ButtonDeckClient.Arduino
{
    class MessageHandler
    {
        private readonly ILogger _logger;
        public event EventHandler<ButtonEventArgs> ButtonDown;
        public event EventHandler<ButtonEventArgs> ButtonUp;
        public event EventHandler<ToggleStateChangeEventArgs> ToggleStateChanged;
        public event EventHandler<LEDBrightnessEventArgs> LEDBrightness;
        public event EventHandler<VersionEventArgs> VersionResponse;
        public event EventHandler<HeartbeatEventArgs> HeartbeatResponse;
        public event EventHandler InvalidResponse;
        public event EventHandler AcknowledgedResponse;

        public MessageHandler(ILogger logger)
        {
            _logger = CategoryLogger.Create(nameof(MessageHandler), logger);
        }

        public void ProcessMessage(Stream stream)
        {
            var headerPart1 = stream.ReadByte();
            if (headerPart1 != 0xFF)
            {
                _logger.WriteLine($"Expected 0xFF header byte 1, recieved '{headerPart1}'");
                return;
            }
            var headerPart2 = stream.ReadByte();
            if (headerPart1 != 0xFA)
            {
                _logger.WriteLine($"Expected 0xFA header byte 2, recieved '{headerPart1}'");
                return;
            }

            var messageId = stream.ReadByte();
            switch (messageId)
            {
                case MessageIds.MESSAGE_INVALID:
                    {
                        var data = stream.ReadByte();
                        _logger.WriteLine($"MESSAGE_INVALID: data={data}");
                        InvalidResponse?.Invoke(this, EventArgs.Empty);
                    }
                    break;
                case MessageIds.MESSAGE_ACKNOWLEDGED:
                    {
                        var data = stream.ReadByte();
                        _logger.WriteLine($"MESSAGE_ACKNOWLEDGED: data={data}");
                        AcknowledgedResponse?.Invoke(this, EventArgs.Empty);
                    }
                    break;
                case MessageIds.MESSAGE_BUTTON_DOWN:
                    {
                        var column = stream.ReadByte();
                        var row = stream.ReadByte();
                        _logger.WriteLine($"MESSAGE_BUTTON_DOWN: column={column},row={row}");
                        ButtonDown?.Invoke(this, new ButtonEventArgs(row, column));
                    }
                    break;
                case MessageIds.MESSAGE_BUTTON_UP:
                    {
                        var column = stream.ReadByte();
                        var row = stream.ReadByte();
                        _logger.WriteLine($"MESSAGE_BUTTON_UP: column={column},row={row}");
                        ButtonUp?.Invoke(this, new ButtonEventArgs(row, column));
                    }
                    break;
                case MessageIds.MESSAGE_TOGGLE_STATE:
                    {
                        var index = stream.ReadByte();
                        var state = stream.ReadByte();
                        _logger.WriteLine($"MESSAGE_TOGGLE_STATE: index={index},state={state}");
                        ToggleStateChanged?.Invoke(this, new ToggleStateChangeEventArgs(index, state == 1));
                    }
                    break;
                case MessageIds.MESSAGE_LED_BRIGHTNESS:
                    {
                        var brightness = stream.ReadByte();
                        _logger.WriteLine($"MESSAGE_LED_BRIGHTNESS: brightness={brightness}");
                        LEDBrightness?.Invoke(this, new LEDBrightnessEventArgs(brightness));
                    }
                    break;
                case MessageIds.MESSAGE_VERSION:
                    {
                        var version = stream.ReadByte();
                        _logger.WriteLine($"MESSAGE_VERSION: version={version}");
                        VersionResponse?.Invoke(this, new VersionEventArgs(version));
                    }
                    break;
                case MessageIds.MESSAGE_HEARTBEAT:
                    {
                        var value = stream.ReadByte();
                        _logger.WriteLine($"MESSAGE_HEARTBEAT: value={value}");
                        HeartbeatResponse?.Invoke(this, new HeartbeatEventArgs(value));
                    }
                    break;
                default:
                    {
                        _logger.WriteLine($"Unexpected message id '{messageId}'");
                        throw new ArgumentOutOfRangeException(nameof(messageId), "Unexpected message id");
                    }
            }
        }
    }

}
