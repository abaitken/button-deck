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
struct PersistantData
{
    byte brightness;
};

PersistantData g_data = {
    255
};

void SaveData();