using System.Net;
using System.Net.Sockets;

namespace Communication.Protocols
{
    public class Tcp
    {
        private IPAddress ip;
        private int port;
        private TcpClient tcpClient = null!;
        private StreamWriter writer = null!;

        public Tcp(IPAddress ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        internal string RecievedMessage
        {
            set { }
        }

        private void Write(string message)
        {
            try
            {
                this.writer.Write(message); //writer might use buffer
                this.writer.Flush(); //flush buffer
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void Connect()
        {
            if (!string.IsNullOrEmpty(ip.ToString()))
            {
                try
                {
                    var ipEndPoint = new IPEndPoint(ip, port);
                    this.tcpClient = new TcpClient();
                    this.tcpClient.Connect(ipEndPoint);

                    this.writer = new StreamWriter(this.tcpClient.GetStream());
                    RecieveAsync();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Not Valid Ip");
                }
            }
        }

        private async void RecieveAsync()
        {
            var reader = new StreamReader(this.tcpClient.GetStream());
            while (true)
            {
                RecievedMessage = await reader.ReadLineAsync();
            }
        }
    }
}