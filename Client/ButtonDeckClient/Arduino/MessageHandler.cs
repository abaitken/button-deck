using System;
using System.IO;

namespace ButtonDeckClient.Arduino
{
    class MessageHandler
    {
        public void ProcessMessages(Stream stream)
        {
            while(true)
            {
                // TODO : Add validation
                var headerPart1 = stream.ReadByte();
                var headerPart2 = stream.ReadByte();

                // TODO : Raise events
                // TODO : Double check data types
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
                        }
                        break;
                    case MessageIds.MESSAGE_BUTTON_UP:
                        {
                            var column = stream.ReadByte();
                            var row = stream.ReadByte();
                        }
                        break;
                    case MessageIds.MESSAGE_TOGGLE_STATE:
                        {
                            var index = stream.ReadByte();
                            var state = stream.ReadByte();
                        }
                        break;
                    case MessageIds.MESSAGE_LED_BRIGHTNESS:
                        {
                            var brightness = stream.ReadByte();
                        }
                        break;
                    case MessageIds.MESSAGE_VERSION:
                        {
                            var version = stream.ReadByte();
                        }
                        break;
                    case MessageIds.MESSAGE_HEARTBEAT:
                        {
                            var value = stream.ReadByte();
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageId), "Unexpected message id");
                }
            }
        }
    }

}
