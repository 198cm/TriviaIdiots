using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TI_Server.Players;

namespace TI_Server.Communication
{
    class ServerReceiver : IReceiver
    {
        public Server Server;
        public ServerClient client;
        public ServerReceiver(Server server, ServerClient client)
        {
            this.Server = server;
            this.client = client;
        }

        public async Task handlePackage(string message)
        {
            string[] data = Regex.Split(message, "``");

            switch (data[0])
            {
                case "Connect":
                    string name = data[1];
                    client.player = new Player(this.client, name);
                    break;
                case "QuestionRequest":
                    string room1 = data[1];

                    ApiRequest request = new ApiRequest();
                    Question q1 = await request.getQuestion();
                    this.Server.AddQuestion(q1);

                    ServerRoom roomA = getRoom(room1);
                    foreach (Player player in roomA.players)
                    {
                        player.sendQuestion(q1);
                    }
                    break;
                case "RoomConnect":
                    string room2 = data[1];

                    if (this.Server.RoomExists(room2))
                    {
                        ServerRoom roomConnect = this.Server.GetRoom(room2);
                        roomConnect.AddPlayer(this.client.player);
                    }

                    break;
                case "RoomShow":
                    Server.sendRoomNamesToClients();
                    break;
                case "RoomCreate":
                    string playerName = data[1];

                    if (this.Server.PlayerExists(playerName))
                    {
                        Player player1 = this.Server.GetPlayer(playerName);
                        this.client.CreateRoom(player1);
                    }

                    Server.sendRoomNamesToClients();
                    break;
                case "RoomStart":
                    string room3 = data[1];

                    ServerRoom roomB = getRoom(room3);
                    roomB.startRoom();

                    ApiRequest request1 = new ApiRequest();
                    Question q2 = await request1.getQuestion();
                    this.Server.AddQuestion(q2);

                    this.client.player.sendQuestion(q2);

                    break;
                case "Answer":
                    string question = data[1];
                    string givenAnswer = data[2];

                    Question q3 = GetQuestion(question);
                    if (q3.IsGivenAnswerCorrect(givenAnswer))
                    {
                        this.client.Write("Answer``True~_~");
                    } else
                    {
                        this.client.Write("Answer``False~_~");
                    }

                    break;
            }
        }

        public ServerRoom getRoom(string roomName)
        {
            if (this.Server.RoomExists(roomName))
            {
                return this.Server.GetRoom(roomName);
                
            }
            return null;
        }

        public Question GetQuestion(string question)
        {
            if (this.Server.QuestionExists(question))
            {
                return this.Server.GetQuestion(question);
            }
            return null;
        }
    }
}
