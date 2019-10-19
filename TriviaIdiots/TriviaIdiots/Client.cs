using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TI_Server.Communication;

namespace TriviaIdiots
{
    public class Client
    {
        private static NetworkStream stream;
        private static byte[] buffer = new byte[1024];
        static string totalBuffer = "";
        private ClientReceiver receiver;


        public Client()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 1017);
            receiver = new ClientReceiver(this);
            stream = client.GetStream();

            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);

        }

        private void OnRead(IAsyncResult ar)
        {
            Console.WriteLine("Received Data");
            int receivedBytes = stream.EndRead(ar);
            totalBuffer += Encoding.ASCII.GetString(buffer, 0, receivedBytes);

            //implement a protocol
            while (totalBuffer.Contains("~_~"))
            {
                string packet = totalBuffer.Substring(0, totalBuffer.IndexOf("~_~"));
                totalBuffer = totalBuffer.Substring(totalBuffer.IndexOf("~_~") + 3);

                this.receiver.handlePackage(packet);
            }

            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        public void Write(string message)
        {
            stream.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
            stream.Flush();
        }

        private void WriteMessageInProtocol(string tag, string[] atr)
        {
            string message = $"{tag}";
            foreach(string part in atr)
            {
                message += $"``{part}";
            }
            message += "~_~";
            Write(message);
        }

        public void SendConnect(string name)
        {
            string[] atr = new string[1];
            atr[0] = name;
            WriteMessageInProtocol("Connect", atr);
        }

        public void SendQuestionRequest(string roomName)
        {
            string[] atr = new string[1];
            atr[0] = roomName;
            WriteMessageInProtocol("QuestionRequest", atr);
        }

        public void SendRoomConnect(string roomName)
        {
            string[] atr = new string[1];
            atr[0] = roomName;
            WriteMessageInProtocol("RoomConnect", atr);
        }

        public void SendRoomShow()
        {
            string[] atr = new string[0];
            WriteMessageInProtocol("RoomShow", atr);
        }

        public void SendRoomCreate(string playerName)
        {
            string[] atr = new string[1];
            atr[0] = playerName;
            WriteMessageInProtocol("RoomCreate", atr);
        }

        public void SendRoomStart(string roomName)
        {
            string[] atr = new string[1];
            atr[0] = roomName;
            WriteMessageInProtocol("RoomStart", atr);
        }

        public void SendAnswer(string question, string answer)
        {
            string[] atr = new string[2];
            atr[0] = question;
            atr[1] = answer;
            WriteMessageInProtocol("Answer", atr);
        }
    }
}
