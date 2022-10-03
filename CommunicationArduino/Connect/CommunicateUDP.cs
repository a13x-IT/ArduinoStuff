using System;
using CommunicationArduino.Protocols;
namespace Communication.Connect;
partial class CommunicateUDP : ICommunicate{
    private Udp udp;
    public void Initialize(IPAddress serverIpAddress, IPAddress arduinoIpAddress, int port){
        udp = new Udp(IPAddress serverIpAddress, IPAddress arduinoIpAddress, int port);
    }
    public void Send(string message){
        udp.Send(message);
    }
    public string Receive(){
        ReceiveAsync();
        return Result;
    }
}