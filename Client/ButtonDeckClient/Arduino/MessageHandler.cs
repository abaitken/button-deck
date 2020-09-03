using System;
using System.IO;

namespace ButtonDeckClient.Arduino
{
    class MessageHandler
    {
        public EventHandler<ButtonEventArgs> ButtonDown;
        public EventHandler<ButtonEventArgs> ButtonUp;
        public EventHandler<ToggleStateChangeEventArgs> ToggleStateChanged;
        public EventHandler<LEDBrightnessEventArgs> LEDBrightness;
        public EventHandler<VersionEventArgs> VersionResponse;
        public EventHandler<HeartbeatEventArgs> HeartbeatResponse;

        public void ProcessMessages(Stream stream)
        {
            while(true)
            {
                // TODO : Add validation
                var headerPart1 = stream.ReadByte();
                var headerPart2 = stream.ReadByte();

                var messageId = stream.ReadByte();
                switch (messageId)
                {
                    case MessageIds.MESSAGE_INVALID:
                        _ = stream.ReadByte();
                        break;
                    case MessageIds.MESSAGE_ACKNOWLEDGED:
                        _ = stream.ReadByte();
                        break;
                    case MessageIds.MESSAGE_BUTTON_DOWN:
                        {
                            var column = stream.ReadByte();
                            var row = stream.ReadByte();
                            ButtonDown?.Invoke(this, new ButtonEventArgs(row, column));
                        }
                        break;
                    case MessageIds.MESSAGE_BUTTON_UP:
                        {
                            var column = stream.ReadByte();
                            var row = stream.ReadByte();
                            ButtonUp?.Invoke(this, new ButtonEventArgs(row, column));
                        }
                        break;
                    case MessageIds.MESSAGE_TOGGLE_STATE:
                        {
                            var index = stream.ReadByte();
                            var state = stream.ReadByte();
                            ToggleStateChanged?.Invoke(this, new ToggleStateChangeEventArgs(index, state == 1));
                        }
                        break;
                    case MessageIds.MESSAGE_LED_BRIGHTNESS:
                        {
                            var brightness = stream.ReadByte();
                            LEDBrightness?.Invoke(this, new LEDBrightnessEventArgs(brightness));
                        }
                        break;
                    case MessageIds.MESSAGE_VERSION:
                        {
                            var version = stream.ReadByte();
                            VersionResponse?.Invoke(this, new VersionEventArgs(version));
                        }
                        break;
                    case MessageIds.MESSAGE_HEARTBEAT:
                        {
                            var value = stream.ReadByte();
                            HeartbeatResponse?.Invoke(this, new HeartbeatEventArgs(value));
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageId), "Unexpected message id");
                }
            }
        }
    }

}
