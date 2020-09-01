// Communications
void SendSerialMessage(byte identifier, byte data);

// Buttons
void SendToggleState(int pinIndex);

// Lighting
#include "FastLED.h"
void SetLEDState(int index, CRGB color);
void CommitLEDStates();
byte GetBrightness();
void SetBrightness(byte value);

// EEPROM
#define STORE_BRIGHTNESS       0
#define STORE_NEXT             STORE_BRIGHTNESS + sizeof(int)
