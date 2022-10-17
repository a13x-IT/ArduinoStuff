using System.IO.Ports;
using Communication.Protocols;

namespace Communication.Connect;

internal class CommunicateSerial : ICommunicate
{
    private Serial serial;


    internal CommunicateSerial(string port)
    {
        serial = new Serial(port);
    }

    public void Send(string message)
    {
        serial.Write(message);
    }

    public string Receive(SerialDataReceivedEventHandler handler)
    {
        serial.SerialDataReceivedEventHandler(handler);
        return null;
    }

    private string test()
    {
    }
}