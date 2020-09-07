using ButtonDeckClient.Logging;
using System;
using System.Data.Common;

namespace ButtonDeckClient.Arduino
{
    internal class MessageBuilder
    {
        public const byte HEADER1 = 0xFF;
        public const byte HEADER2 = 0xFA;
        private readonly ILogger _logger;

        public MessageBuilder(ILogger logger)
        {
            _logger = CategoryLogger.Create(nameof(MessageBuilder), logger);
        }

        private byte[] Build(byte messageId, params byte[] data)
        {
            var result = new byte[data.Length + 3];
            result[0] = HEADER1;
            result[1] = HEADER2;
            result[2] = messageId;
            if(data.Length != 0)
                Buffer.BlockCopy(data, 0, result, 3, data.Length);
            return result;
        }

        public byte[] GetToggleState(byte toggleIndex)
        {
            _logger.WriteLine($"MESSAGE_TOGGLE_STATE: toggleIndex={toggleIndex}");
            return Build(MessageIds.MESSAGE_TOGGLE_STATE, toggleIndex);
        }

        public byte[] GetLedBrightness()
        {
            return SetLedBrightness(0);
        }

        public byte[] SetLedBrightness(byte brightness)
        {
            _logger.WriteLine($"MESSAGE_LED_BRIGHTNESS: brightness={brightness}");
            return Build(MessageIds.MESSAGE_LED_BRIGHTNESS, brightness);
        }

        public byte[] GetVersion()
        {
            _logger.WriteLine($"MESSAGE_VERSION");
            return Build(MessageIds.MESSAGE_VERSION);
        }

        public byte[] Heartbeat(byte number)
        {
            _logger.WriteLine($"MESSAGE_HEARTBEAT: number={number}");
            return Build(MessageIds.MESSAGE_HEARTBEAT, number);
        }

        public byte[] SetLedColor(byte index, RGB color)
        {
            return SetManyLedColor(new[] { index }, new[] { color });
        }

        public byte[] SetManyLedColor(byte[] indexes, RGB[] colors)
        {
            // TODO : Also check we're not changing more than 255 of them
            if (indexes.Length != colors.Length)
                throw new ArgumentOutOfRangeException();

            var data = new byte[(indexes.Length * 4) + 1];
            data[0] = indexes.Length.ToByte();
            for (int i = 0; i < indexes.Length; i++)
            {
                var offset = (i * 4) + 1;
                var index = indexes[i];
                data[offset++] = index;
                var color = colors[i];
                data[offset++] = color.R;
                data[offset++] = color.G;
                data[offset++] = color.B;
                _logger.WriteLine($"MESSAGE_LED_COLOR: index={index},R={color.R},G={color.G},B={color.B}");
            }

            return Build(MessageIds.MESSAGE_LED_COLOR, data);
        }
    }
}
