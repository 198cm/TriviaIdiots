using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TI_Server.Players;
using TI_Server;
using System.Threading.Tasks;

namespace TI_Server.Communication
{
    class ClientReceiver : IReceiver
    {
        private ClientRoom cr;
        public ClientReceiver(ClientRoom cr)
        {
            this.cr = cr;
        }
        public void handlePackage(string message)
        {
            string[] data = Regex.Split(message, "``");

            switch (data[0])
            {
                case "Question":

                    break;
                case "PlayerJoin":
                    cr.playerNames.Add((string) data[1]);
                    break;
                case "PlayerLeave":
                    cr.playerNames.Remove((string) data[1]);

                    break;
                case "AnswerCheck":

                    break;
                case "Roomcode":
                    cr.roomcode = (string)data[1];
                    break;
                case "Start":
                    //ReadyGame();
                    break;
            }
        }

        Task IReceiver.handlePackage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
