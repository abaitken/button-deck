using System;

namespace ButtonDeckClient.Arduino
{
    internal class VersionEventArgs : EventArgs
    {
        public VersionEventArgs(int version)
        {
            Version = version;
        }

        public int Version { get; }
    }

}
