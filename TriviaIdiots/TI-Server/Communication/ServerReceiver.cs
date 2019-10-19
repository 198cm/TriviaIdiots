using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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

        public void handlePackage(string message)
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


                    break;
                case "RoomConnect":
                    string room2 = data[1];

                    break;
                case "RoomShow":

                    break;
                case "RoomCreate":
                    string roomName = data[1];
                    break;
                case "RoomStart": break;
                case "Answer":
                    string player1 = data[1];
                    string question = data[2];
                    string givenAnswer = data[3];



                    break;
            }
        }
    }
}
