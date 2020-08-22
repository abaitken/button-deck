using System;

namespace ButtonDeckClient.Arduino
{
    public interface ICommandReciever : IDisposable
    {
        void Connect();
        void Disconnect();
    }
}
