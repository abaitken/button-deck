#include "constants.h"
#include "shared.h"
#include "buttons.h"
#include "lighting.h"
#include "communication.h"

void setup()
{
    SetupLighting();
    SetupButtons();
    SetupCommunications();
}

void loop()
{
    CheckButtonStates();
    if(!ProcessSerialMessages())
        delay(5); // TODO : Is this required? Concerned about overheating?
}