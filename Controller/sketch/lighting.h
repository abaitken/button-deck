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
    return g_data.brightness;
}

void SetBrightness(byte value)
{
    g_data.brightness = value;
    FastLED.setBrightness(value);
    SaveData();
}

void SetupLighting()
{
    // TODO : Maybe RGB ordering instead?
    FastLED.addLeds<WS2812, PIN_LED, GRB>(g_ledStates, NUM_LEDS);    
    SetBrightness(GetBrightness());
    SetLEDState(0, CRGB::Red);
    CommitLEDStates();
}