# ArduinoStuff
A small library to easily talk to an Arduino written in C#

## Supported Protocols
- UDP
- TCP
- Serial

## How to use
1 Create a new instance of `IConnect` and initialize it with the protocol to be used

    IConntect serial = new Serial("COM3);
2 Use the .Send Method to send a string to the Arduino

    serial.send("<your message>");
3 Use the .Receive Method to asynchronously recieve a string 

    serial.Recieve();

## Where to use
This library may be used in any Verion of the .NET Core 6.0 (and older) there may be support for older Verions of the .NET Core

There will be example code provided for both the C#-Library and the Arduino-Client. 
