using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using TI_Server.Players;

namespace TI_Server
{
    class ServerClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        public Player player;

        private byte[] buffer = new byte[1024];
        string totalBuffer = "";

        public ServerClient(TcpClient newTcpClient)
        {
            this.tcpClient = newTcpClient;

            this.stream = tcpClient.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void OnRead(IAsyncResult ar)
        {
            
            int receivedBytes = stream.EndRead(ar);
            totalBuffer += Encoding.ASCII.GetString(buffer, 0, receivedBytes);

            Console.WriteLine($"Received Data From Client: {totalBuffer}");
            //implement protocol
            handlePackage();

            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void handlePackage()
        {
        }
    }
}
