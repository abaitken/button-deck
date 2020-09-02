namespace ButtonDeckClient.Arduino
{
    struct RGB
    {
        public RGB(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public byte R { get; }
        public byte G { get; }
        public byte B { get; }
    }
}
