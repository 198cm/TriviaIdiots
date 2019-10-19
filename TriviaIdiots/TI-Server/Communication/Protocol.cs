using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TI_Server.Players;

namespace TI_Server.Communication
{
    class Protocol
    {
        private Server server = null;

        public Protocol()
        {

        }

        public Protocol(Server server)
        {
            this.server = server;
        }

        public void handlePackage(string message)
        {
            string[] data = Regex.Split(message, "``");

            switch (data[0])
            {
                
                case "Question":
                    string question = data[1];
                    string category = data[2];
                    string correctAnswer = data[3];
                    string incorrectAnswer1 = data[4];
                    string incorrectAnswer2 = data[5];
                    string incorrectAnswer3 = data[6];

                    break;
                
                
                
            }


            
        }

    }


}
