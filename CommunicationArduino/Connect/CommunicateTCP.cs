using System.Net;
using Communication.Protocols;

namespace Communication.Connect;

internal class CommunicateTCP : ICommunicate
{
    private Tcp tcp;

    internal CommunicateTCP(IPAddress ip, int port)
    {
        tcp = new Tcp(ip, port);
        tcp.Connect();
    }

    public void Send(string message)
    {
        tcp.Send(message);
    }

    public string Receive()
    {
        return RecievedMessage;
    }
}