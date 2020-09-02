using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.Arduino
{
    // TODO : Replace with T4 template to parse values from constants.h
    static class MessageIds
    {
        public const byte MESSAGE_INVALID = 1;
        public const byte MESSAGE_ACKNOWLEDGED = MESSAGE_INVALID + 1;
        public const byte MESSAGE_BUTTON_DOWN = MESSAGE_ACKNOWLEDGED + 1;
        public const byte MESSAGE_BUTTON_UP = MESSAGE_BUTTON_DOWN + 1;
        public const byte MESSAGE_TOGGLE_STATE = MESSAGE_BUTTON_UP + 1;
        public const byte MESSAGE_LED_BRIGHTNESS = MESSAGE_TOGGLE_STATE + 1;
        public const byte MESSAGE_LED_COLOR = MESSAGE_LED_BRIGHTNESS + 1;
        public const byte MESSAGE_VERSION = MESSAGE_LED_COLOR + 1;
        public const byte MESSAGE_HEARTBEAT = MESSAGE_VERSION + 1;
        //const byte MESSAGE_NEXT = MESSAGE_HEARTBEAT + 1;
    }

}
