using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TI_Server.Players;

namespace TI_Server
{
    class Server
    {
        

        public static void Main(string[] args)
        {
            new Server();
        }

        ConcurrentBag<Player> players = new ConcurrentBag<Player>();
        ConcurrentBag<Question> questions = new ConcurrentBag<Question>();
        ConcurrentBag<ServerRoom> rooms = new ConcurrentBag<ServerRoom>();
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
            clients.Add(new ServerClient(newTcpClient, this));
            
            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }

        public void addPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void addRoom(ServerRoom room)
        {
            this.rooms.Add(room);
        }

        public void AddQuestion(Question q1)
        {
            this.questions.Add(q1);
        }

        public void sendRoomNamesToClients()
        {
            string message = "Rooms``";
            foreach(ServerRoom room in rooms)
            {
                message += room.roomName + "``";
            }
            message += "~_~";
            Broadcast(message);
        }

        public void Broadcast(string message)
        {
            foreach(ServerClient client in clients)
            {
                client.Write(message);
            }
        }

        public bool RoomExists(string roomName)
        {
            foreach(ServerRoom room in rooms)
            {
                if(room.roomName == roomName)
                {
                    return true;
                }
            }
            return false;
        }

        public ServerRoom GetRoom(string roomName)
        {
            foreach(ServerRoom room in rooms)
            {
                if (room.roomName == roomName)
                {
                    return room;
                }
            }
            return null;
        }

        public bool QuestionExists(string question)
        {
            foreach(Question q1 in questions)
            {
                if(q1.question == question)
                {
                    return true;
                }
            }
            return false;
        }

        public Question GetQuestion(string question)
        {
            foreach(Question q1 in questions)
            {
                if (q1.question == question)
                {
                    return q1;
                }
            }
            return null;
        }

        public bool PlayerExists(string playerName)
        {
            foreach(Player player1 in players)
            {
                if(player1.name == playerName)
                {
                    return true;
                }
            }
            return false;
        }

        public Player GetPlayer(string playerName)
        {
            foreach (Player player1 in players)
            {
                if (player1.name == playerName)
                {
                    return player1;
                }
            }
            return null;
        }
    }
}
