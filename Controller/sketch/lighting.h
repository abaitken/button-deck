#include <EEPROM.h>

CRGB g_ledStates[NUM_LEDS];

void SetLEDState(int index, CRGB color)
{
    g_ledStates[index] = color;
}

void CommitLEDStates()
{
    FastLED.show();
}

byte GetBrightness()
{
    // TODO : Implement checksums: https://forum.arduino.cc/index.php?topic=578012.0
    return EEPROM.read(STORE_BRIGHTNESS);
}

void SetBrightness(byte value)
{
    EEPROM.write(STORE_BRIGHTNESS, value);
    FastLED.setBrightness(value);
}

void SetupLighting()
{
    // TODO : Maybe RGB ordering instead?
    FastLED.addLeds<WS2812, PIN_LED, GRB>(g_ledStates, NUM_LEDS);    
    SetBrightness(GetBrightness());
    SetLEDState(0, CRGB::Red);
    CommitLEDStates();
}