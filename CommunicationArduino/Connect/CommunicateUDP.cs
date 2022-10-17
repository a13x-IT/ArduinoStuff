namespace Communication.Connect;

partial class CommunicateUDP : ICommunicate
{
    private Udp udp;

    public CommunicateUDP(IPAddress serverIpAddress, IPAddress arduinoIpAddress, int port)
    {
        udp = new Udp(serverIpAddress, arduinoIpAddress, port);
    }

    public void Send(string message)
    {
        udp.Send(message);
    }

    public string Receive()
    {
        ReceiveAsync();
        return Result;
    }
}