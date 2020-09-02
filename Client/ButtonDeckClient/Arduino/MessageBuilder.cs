namespace ButtonDeckClient.Arduino
{
    internal class MessageBuilder
    {
        public byte[] GetToggleState(byte toggleIndex)
        {
            return new byte[]
            {
                0, 0, MessageIds.MESSAGE_TOGGLE_STATE, toggleIndex
            };
        }

        public byte[] GetLedBrightness()
        {
            return SetLedBrightness(0);
        }

        public byte[] SetLedBrightness(byte brightness)
        {
            return new byte[]
            {
                0, 0, MessageIds.MESSAGE_LED_BRIGHTNESS, brightness
            };
        }

        public byte[] GetVersion()
        {
            return new byte[]
            {
                0, 0, MessageIds.MESSAGE_VERSION
            };
        }

        public byte[] Heartbeat(byte number)
        {
            return new byte[]
            {
                0, 0, MessageIds.MESSAGE_HEARTBEAT, number
            };
        }

        public byte[] SetLedColor(byte index, RGB color)
        {
            return new byte[]
            {
                0, 0, MessageIds.MESSAGE_LED_COLOR, index, color.R, color.G, color.B
            };
        }
    }
}
