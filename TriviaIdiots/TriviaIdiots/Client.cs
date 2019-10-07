using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TriviaIdiots
{
    class Client
    {
        private static NetworkStream stream;
        private static byte[] buffer = new byte[1024];
        static string totalBuffer = "";


        public Client()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 1017);

            stream = client.GetStream();

            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);

        }

        private void OnRead(IAsyncResult ar)
        {
            Console.WriteLine("Received Data");
            int receivedBytes = stream.EndRead(ar);
            totalBuffer += Encoding.ASCII.GetString(buffer, 0, receivedBytes);

            //implement a protocol
            handlePackage();

            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void handlePackage()
        {

        }

        
    }
}
