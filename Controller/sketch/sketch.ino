//https://www.arduino.cc/en/Reference/PortManipulation
//https://tronixstuff.com/2011/10/22/tutorial-arduino-port-manipulation/

byte g_previousPortD;
byte g_currentPortD;

void setup() {
	Serial.begin(9600);
	// Set as input by default
	//DDRD = B00000000; // set PORTD (digital 7~0) to inputs
	
	// TODO : Negotiate with host? Set serial speed and delay?
}

void loop() {
	
	g_currentPortD = PIND;
	
	if(g_currentPortD != g_previousPortD)
	{
		g_previousPortD = g_currentPortD;
		Serial.println(g_currentPortD);
	}
	
	delay(200);
}