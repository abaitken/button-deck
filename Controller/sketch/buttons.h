
const int g_buttonRowCount = sizeof(g_buttonRowPins) / sizeof(g_buttonRowPins[0]);
const int g_buttonColumnCount = sizeof(g_buttonColumnPins) / sizeof(g_buttonColumnPins[0]);
const int g_toggleCount = sizeof(g_togglePins) / sizeof(g_togglePins[0]);

bool g_buttonStates[g_buttonColumnCount][g_buttonRowCount];
bool g_toggleState[g_toggleCount];

bool GetToggleState(int pinIndex)
{
    byte pin = g_togglePins[pinIndex];
    if(pin != A6 && pin != A7)
        return digitalRead(pin) == HIGH;

    return analogRead(pin) < 500 ? true : false;
}

void SetupButtons()
{
    // Setup pins
    for (int pinIndex = 0; pinIndex < g_buttonRowCount; pinIndex++)
    {
        pinMode(g_buttonRowPins[pinIndex], INPUT);
    }

    for (int pinIndex = 0; pinIndex < g_buttonColumnCount; pinIndex++)
    {
        pinMode(g_buttonColumnPins[pinIndex], INPUT_PULLUP);
    }
    
    // Initialise button state storage
    for (int columnPinIndex = 0; columnPinIndex < g_buttonColumnCount; columnPinIndex++)
    {
        for (int rowPinIndex = 0; rowPinIndex < g_buttonRowCount; rowPinIndex++)
        {
            g_buttonStates[columnPinIndex][rowPinIndex] = false;
        }
    }
    
    // Initialise toggle states
    for (int pinIndex = 0; pinIndex < g_toggleCount; pinIndex++)
    {
        byte pin = g_togglePins[pinIndex];
        if(pin != A6 && pin != A7)
            pinMode(pin, INPUT_PULLUP);

        g_toggleState[pinIndex] = GetToggleState(pinIndex);
    }
}

void SendToggleState(int pinIndex)
{
    if(pinIndex >= g_toggleCount)
        SendSerialMessage(MESSAGE_INVALID, 0);
    else
        SendSerialMessage(MESSAGE_TOGGLE_STATE, word(pinIndex, g_togglePins[pinIndex]));
}

void CheckButtonStates()
{
    bool currentState;
    for (int columnPinIndex = 0; columnPinIndex < g_buttonColumnCount; columnPinIndex++)
    {
        byte columnPin = g_buttonColumnPins[columnPinIndex];
        pinMode(columnPin, OUTPUT);
        digitalWrite(columnPin, LOW);

        for (int rowPinIndex = 0; rowPinIndex < g_buttonRowCount; rowPinIndex++)
        {
            byte rowPin = g_buttonRowPins[rowPinIndex];
            pinMode(rowPin, INPUT_PULLUP);
            currentState = digitalRead(rowPin) == HIGH;            
            pinMode(rowPin, INPUT);

            // TODO : Should this be done outside the loop? Could it cause the check to slow down?
            // TODO : Should the column and row map to a simple button index?
            if(g_buttonStates[columnPinIndex][rowPinIndex] != currentState)
            {
                if(currentState)
                    SendSerialMessage(MESSAGE_BUTTON_DOWN, word(columnPinIndex, rowPinIndex));
                else
                    SendSerialMessage(MESSAGE_BUTTON_UP, word(columnPinIndex, rowPinIndex));
            }
            g_buttonStates[columnPinIndex][rowPinIndex] = currentState;
        }

        pinMode(columnPin, INPUT);
    }

    for (int pinIndex = 0; pinIndex < g_toggleCount; pinIndex++)
    {
        currentState = GetToggleState(pinIndex);

        if(g_toggleState[pinIndex] != currentState)
        {
            g_toggleState[pinIndex] = currentState;
            SendToggleState(pinIndex);
        }
    }
}