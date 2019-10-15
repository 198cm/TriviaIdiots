using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TI_Server
{
    class Server
    {
        public static async Task Main(string[] args)
        {

            ApiRequest api = new ApiRequest();
            QuestionPack qpack = await api.getQuestionsAsync(5);

            Console.WriteLine(qpack.ToString());

            

            //new Server();
        }

        TcpListener listener;
        private List<ServerClient> clients = new List<ServerClient>();

        public Server()
        {
            listener = new TcpListener(IPAddress.Any, 1017);
            listener.Start();
            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
            Console.ReadKey();
        }

        private void OnConnect(IAsyncResult ar)
        {
            var newTcpClient = listener.EndAcceptTcpClient(ar);
            Console.WriteLine("New client connected");
            clients.Add(new ServerClient(newTcpClient));

            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }


    }
}
