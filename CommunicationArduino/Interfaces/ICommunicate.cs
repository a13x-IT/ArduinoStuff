namespace Communication;
public interface ICommunicate
{
    void Connect();
    string Send(string message);
    string Receive();
}