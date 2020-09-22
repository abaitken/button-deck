using System;

namespace ButtonDeckClient.Arduino
{
    public class VersionEventArgs : EventArgs
    {
        public VersionEventArgs(int version)
        {
            Version = version;
        }

        public int Version { get; }
    }

}
