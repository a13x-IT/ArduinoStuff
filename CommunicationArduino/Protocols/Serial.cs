using System.IO.Ports;

namespace Communication.Protocols
{
    internal class Serial
    {
        /*
         * TODO: Making it dynamic
         * TODO: Interfacing to outside
         * 
         */
        private SerialPort serialPort;

        //Opens Serial Port
        internal Serial(string port) //port: COM3
        {
            this.serialPort = new SerialPort(port, 9600, Parity.None, (int)StopBits.One);
            this.serialPort.Open();
        }

        internal SerialPort SerialPort { get; }

        //subscribing to the event "Receiving Data"; if we receive Data this Method will be called
        internal void SerialDataReceivedEventHandler(SerialDataReceivedEventHandler handler)
        {
            serialPort.DataReceived += handler;
        }

        //Write Data to the Serial Port
        internal void Write(string value)
        {
            try
            {
                this.serialPort.Write(value);
            }
            catch (Exception e)
            {
                //TODO: Error Handeling
                Console.WriteLine(e);
                throw;
            }
        }
    }
}