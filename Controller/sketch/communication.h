byte g_readByte;

void SetupCommunications()
{
    Serial.begin(BAUD_RATE);
    while (!Serial)
    {
        ; // wait for serial port to connect. Needed for native USB port only
    }

    // TODO : Negotiate with PC?
    /*
  while(true) {
    Serial.println('1');
    g_ledStates[0] = CRGB::Yellow;
    FastLED.show();
    delay(250);
    g_ledStates[0] = CRGB::Black;
    FastLED.show();
    delay(150);

    if(Serial.available()){
      while(Serial.available()>0){
        g_readByte = Serial.read();
        Serial.print(g_readByte);
      }

      Serial.println();
      if(Serial.available()){
        g_ledStates[0] = CRGB::Red;
        FastLED.show();
        while(true){
          delay(10);
        }
      }

      g_ledStates[0] = CRGB::Green;
      FastLED.show();
      break;
    }
  }*/
}

// TODO : Fix the data to be an array?
void SendSerialMessage(byte identifier, byte data)
{
    Serial.write(0);
    Serial.write(0);
    Serial.write(identifier);
    Serial.write(data);
}

void SendSerialMessage(byte identifier, byte data1, byte data2)
{
    Serial.write(0);
    Serial.write(0);
    Serial.write(identifier);
    Serial.write(data1);
    Serial.write(data2);
}

void FlushSerial()
{
    while (Serial.available() > 0)
    {
        Serial.read();
    }
}

void ProcessMessage()
{
    // TODO : What if the next byte was not sent?
    // TODO : Only flush until next 00 ?
    // TODO : Message counters? If out of sink reset?
    g_readByte = Serial.read();

    if (g_readByte != 0)
    {
        FlushSerial();
        SendSerialMessage(MESSAGE_INVALID, 0);
        return;
    }

    g_readByte = Serial.read();

    if (g_readByte != 0)
    {
        FlushSerial();
        SendSerialMessage(MESSAGE_INVALID, 0);
        return;
    }

    // Read message header
    g_readByte = Serial.read();

    byte count, ledIndex, r, g, b;
    switch (g_readByte)
    {
    case MESSAGE_LED_COLOR:
        // Change count
        count = Serial.read();

        for (; count > 0; count--)
        {
            ledIndex = Serial.read();
            r = Serial.read();
            g = Serial.read();
            b = Serial.read();
            SetLEDState(ledIndex, CRGB(r, g, b));
        }

        CommitLEDStates();
        break;

    case MESSAGE_LED_BRIGHTNESS:
        // Brightness value
        g_readByte = Serial.read();
        if (g_readByte == 0)
            SendSerialMessage(MESSAGE_LED_BRIGHTNESS, GetBrightness());
        else if (g_readByte > 255)
            SendSerialMessage(MESSAGE_INVALID, 0);
        else
        {
            SetBrightness(g_readByte);
            SendSerialMessage(MESSAGE_LED_BRIGHTNESS, g_readByte);
        }
        break;

    case MESSAGE_TOGGLE_STATE:
        // Pin index
        g_readByte = Serial.read();
        SendToggleState(g_readByte);
        break;
    case MESSAGE_VERSION:
        SendSerialMessage(MESSAGE_VERSION, VERSION);
        break;
    case MESSAGE_HEARTBEAT:
        g_readByte = Serial.read();
        SendSerialMessage(MESSAGE_HEARTBEAT, g_readByte);
        break;
    default:
        FlushSerial();
        SendSerialMessage(MESSAGE_INVALID, 0);
        break;
    }
}

bool ProcessSerialMessages()
{
    if (!Serial.available())
        return false;

    while (Serial.available() > 0)
    {
        ProcessMessage();
    }
    return true;
}
