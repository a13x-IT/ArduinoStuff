using System;
using CommunicationArduino.Protocols;
namespace Communication.Connect;
partial class Communicate : ICommunicate{
    private Tcp tcp;
    public void Initialize(IPAddress ip, int port){
        tcp = new Tcp(IPAddress ip, int port);
        tcp.Connect();
    }
    public void Send(string message){
        tcp.Send(message);
    }
    public string Receive(){
        ReceiveAsync();
        return RecievedMessage;
    }
}