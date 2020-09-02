using OBS.WebSocket.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.Integrations.OBS
{
    public class OBSConnection
    {
        public OBSConnection()
        {
            var obs = new ObsWebSocket();
            var obsApi = new ObsWebSocketApi(obs);
            // TODO 
        }
    }
}
