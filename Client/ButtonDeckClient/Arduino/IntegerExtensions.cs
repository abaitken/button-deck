using System;

namespace ButtonDeckClient.Arduino
{
    internal static class IntegerExtensions
    {
        public static byte ToByte(this int value)
        {
            if (value < byte.MinValue || value > byte.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(value));

            return (byte)value;
        }
    }
}
