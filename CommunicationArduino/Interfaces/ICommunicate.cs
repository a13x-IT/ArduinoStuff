using System.IO.Ports;

namespace Communication;

public interface ICommunicate
{
    public void Send(string message);
    public string Receive();
    public string Recieve(SerialDataReceivedEventHandler handler);
}