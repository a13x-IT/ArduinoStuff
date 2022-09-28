using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommunicationArduino.Protocols
{
    public class Udp
    {
        private int port = 8888;
        private UdpClient udpClient;

        public Udp()
        {
            IPEndPoint recieveAdr = new IPEndPoint(IPAddress.Any, port); //IP: 0.0.0.0
            udpClient = new UdpClient(recieveAdr);
            this.RecieveAsync();
        }

        //awaits new data from Arduino
        internal async void RecieveAsync()
        {
            while (true)
            {
                UdpReceiveResult result = await udpClient.ReceiveAsync();
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
                byte[] message = Encoding.UTF8.GetBytes(msg);
                IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, this.port);
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