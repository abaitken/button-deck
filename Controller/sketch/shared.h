// Communications
void SendSerialMessage(byte identifier, byte data);
void SendSerialMessage(byte identifier, byte data1, byte data2);

// Buttons
void SendToggleState(int pinIndex);

// Lighting
#include "FastLED.h"
void SetLEDState(int index, CRGB color);
void CommitLEDStates();
byte GetBrightness();
void SetBrightness(byte value);

// EEPROM
struct PersistantData
{
    byte brightness;
};

PersistantData g_data = {
    255
};

void SaveData();