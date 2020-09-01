#include "constants.h"
#include "shared.h"
#include "buttons.h"
#include "lighting.h"
#include "communication.h"
#include "storage.h"

void setup()
{
    SetupLighting();
    SetupButtons();
    SetupStorage();
    SetupCommunications();

    SetLEDState(0, CRGB::Green);
    CommitLEDStates();
}

void loop()
{
    CheckButtonStates();
    if(!ProcessSerialMessages())
        delay(5); // TODO : Is this required? Concerned about overheating?
}