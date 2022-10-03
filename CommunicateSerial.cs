using System;
using CommunicationArduino.Protocols;
namespace Communication.Connect;
internal class CommunicateSerial : ICommunicate{
    private Serial serial;
    public void Initialize(string port){
        ArduinoSerialPortCommunication(port);
    }
    public void Send(string message){
        serial.Send(message);
    }
    public string Receive(SerialDataReceivedEventHandler handler){
        serialPort.DataReceived += handler;
        reader serialPort.DataReceived;
    }
}