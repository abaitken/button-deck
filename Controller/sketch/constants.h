// LEDs
#define PIN_LED 12
#define NUM_LEDS 59

// Buttons
byte g_buttonRowPins[] = {2, 3, 4, 5, 6};
byte g_buttonColumnPins[] = {7, 8, 9, 10, 11};

byte g_togglePins[] = { A0, A1, A2, A3, A4 };

// Comms
#define VERSION   1
#define BAUD_RATE 9600

#define MESSAGE_INVALID         1
#define MESSAGE_ACKNOWLEDGED    MESSAGE_INVALID        + 1
#define MESSAGE_BUTTON_DOWN     MESSAGE_ACKNOWLEDGED   + 1
#define MESSAGE_BUTTON_UP       MESSAGE_BUTTON_DOWN    + 1
#define MESSAGE_TOGGLE_STATE    MESSAGE_BUTTON_UP      + 1
#define MESSAGE_LED_BRIGHTNESS  MESSAGE_TOGGLE_STATE   + 1
#define MESSAGE_LED_COLOR       MESSAGE_LED_BRIGHTNESS + 1
#define MESSAGE_VERSION         MESSAGE_LED_COLOR      + 1
#define MESSAGE_HEARTBEAT       MESSAGE_VERSION        + 1
#define MESSAGE_NEXT            MESSAGE_HEARTBEAT      + 1
