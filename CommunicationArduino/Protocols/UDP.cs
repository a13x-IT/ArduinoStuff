using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Communication.Protocols
{
    public class Udp
    {
        private readonly int port;
        private IPAddress arduinoIpAddress;
        private UdpClient udpClient;

        public Udp(IPAddress serverIpAddress, IPAddress arduinoIpAddress, int port)
        {
            var recieveAdr = new IPEndPoint(serverIpAddress, port); //IP: 0.0.0.0
            udpClient = new UdpClient(recieveAdr);
            this.RecieveAsync();
            this.arduinoIpAddress = arduinoIpAddress;
            this.port = port;
        }

        //awaits new data from Arduino
        internal async void RecieveAsync()
        {
            while (true)
            {
                var result = await udpClient.ReceiveAsync();
                // this.txtLog.Text += Encoding.UTF8.GetString(result.Buffer) + Environment.NewLine;
            }
        }

        internal void Send(string msg)
        {
            /*
             * TODO: Error Handeling
             * TODO: Interfacing to outside
             * TODO: Making it all dynamic
             */
            try
            {
                var message = Encoding.UTF8.GetBytes(msg);
                IPEndPoint ip = new IPEndPoint(this.arduinoIpAddress, this.port);
                udpClient.Send(message, msg.Length, ip);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}