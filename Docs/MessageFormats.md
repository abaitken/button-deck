# Serial Message Formats

This page documents the data format for messages that are sent between the arduino and the PC.

## Basic Format

All messages follow a similar header. Two zeros (00) followed by a byte which indicates the message type, followed by a number of bytes specific to the message.

This documentation will use the following format to describe the messages:

```00 MESSAGE_XYZ value```

This resprents consecutive bytes (without any spaces) containing the information. In the example above, this could be:

```0012```

Where:
 - 00 is the indicator for a new message
 - 1 is the message type
 - 2 is a value for that message

## Messages

See constants.h for exact values


### Invalid/Unexpected state (MESSAGE_INVALID)

Sent from the arduino to indicate the last message/state was invalid.

#### Format

Standard header followed by an unused byte.

```00 MESSAGE_INVALID 0```


### Acknowledged (MESSAGE_ACKNOWLEDGED)

Unused. Informs that the previous message was acknowledged.

#### Format

Standard header followed by an unused byte.

```00 MESSAGE_ACKNOWLEDGED 0```


### Button down (MESSAGE_BUTTON_DOWN)

A button is pressed.

#### Format

Standard header followed by two bytes, where the first is the button matrix column and the second is the row.

```00 MESSAGE_BUTTON_DOWN column row```


### Button up (MESSAGE_BUTTON_UP)

A button is no longer pressed.

#### Format

Standard header followed by two bytes, where the first is the button matrix column and the second is the row.

```00 MESSAGE_BUTTON_UP column row```


### Toggle state (MESSAGE_TOGGLE_STATE)

Sent if the toggle has changed state.

The toggle state can be requested by sending a message with the requested toggle index.

#### Report status format

Standard header followed by two bytes, where the first is the toggle index and the second is the button state, on or off (1 or 0).

```00 MESSAGE_TOGGLE_STATE index state```

#### Request status format

Standard header followed by a byte, which the toggle index.

```00 MESSAGE_TOGGLE_STATE index```


### LED Brightness (MESSAGE_LED_BRIGHTNESS)

Get or set the LED brightness.

#### Get current brightness

Send a standard header followed by a byte, which is zero (0).

```00 MESSAGE_LED_BRIGHTNESS 0```

The arduino will respond with a message in similar format where the value represents the brightness:

```00 MESSAGE_LED_BRIGHTNESS brightness```

#### Set brightness

Send a standard header followed by a byte, which is a value between 1 and 255.

```00 MESSAGE_LED_BRIGHTNESS brightness```


### Set LED Color (MESSAGE_LED_COLOR)

Set the value of an LED.


#### Format

Standard header followed by a byte, which indicates the number of LEDs to change, followed by a repeating 4 bytes, where the first is the LED index followed by 3 bytes for RGB values (0-255).

```00 MESSAGE_LED_COLOR count index r g b...```

For example:

```00x3911165553000```

 (this example wont use double digit numbers to keep bytes and values aligned)
 
 - 00 standard header
 - x is the message type (MESSAGE_LED_COLOR)
 - 3 number of LEDs to update
 - 9 update LED index 9 with
 - 111 are RGB values R1 G1 B1
 - 6 update LED index 6 with
 - 555 which is RGB values R5 G5 B5
 - 3 update LED index 3 with
 - 000 which is RGB values R0 G0 B0

#### Notes

Index 0 which is the panel status light cannot be set.

### Get Version (MESSAGE_VERSION)

Get the version number of the software running on the Arduino.

#### Format

Send a standard header.

```00 MESSAGE_VERSION```

The arduino will respond with a message in similar format where the value represents the version:

```00 MESSAGE_VERSION version```


### Heartbeat (MESSAGE_HEARTBEAT)

Simple heartbeat type message that replies with the same byte value given.

#### Format

Send a standard header with a byte.

```00 MESSAGE_HEARTBEAT value```

The arduino will respond with a message in similar format where the value represents the given value:

```00 MESSAGE_HEARTBEAT value```