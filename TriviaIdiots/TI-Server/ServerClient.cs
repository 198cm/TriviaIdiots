using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using TI_Server.Communication;
using TI_Server.Players;

namespace TI_Server
{
    class ServerClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private Server server;
        public Player player;
        private ServerReceiver receiver;

        private byte[] buffer = new byte[1024];
        string totalBuffer = "";

        public ServerClient(TcpClient newTcpClient, Server server)
        {
            this.tcpClient = newTcpClient;
            this.server = server;
            this.receiver = new ServerReceiver(server, this);

            this.stream = tcpClient.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void OnRead(IAsyncResult ar)
        {
            
            int receivedBytes = stream.EndRead(ar);
            totalBuffer += Encoding.ASCII.GetString(buffer, 0, receivedBytes);

            while (totalBuffer.Contains("~_~"))
            {
                string packet = totalBuffer.Substring(0, totalBuffer.IndexOf("~_~"));
                totalBuffer = totalBuffer.Substring(totalBuffer.IndexOf("~_~") + 3);

                StreamWriter writer = new StreamWriter(@".\ServerLog.txt", true);
                writer.Write("check");
                writer.WriteLine($"{DateTime.Now.ToString("s")} - {packet}");
                writer.Close();

                this.receiver.handlePackage(packet);
            }

            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        public void Write(string message)
        {
            stream.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
            stream.Flush();
        }

        public void ReceiverPlayer(Player player)
        {
            this.player = player;
            this.server.addPlayer(player);
        }

        public void CreateRoom(Player player)
        {
            string possibleRoomCode = GameHelpCommands.RoomCodeGenerate();
            bool codeIsPossible = false;
            while (!codeIsPossible)
            {
                if (this.server.RoomExists(possibleRoomCode))
                {
                    possibleRoomCode = GameHelpCommands.RoomCodeGenerate();
                }
                codeIsPossible = true;
            }
            ServerRoom room = new ServerRoom(possibleRoomCode);
            Write($"Roomcode``{possibleRoomCode}~_~");
            this.server.addRoom(room);
            room.AddPlayer(this.player);
        }
    }
}
