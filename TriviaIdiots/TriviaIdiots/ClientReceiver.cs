using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using TI_Server;
using TriviaIdiots;
using System.Net;

namespace TI_Server.Communication
{
    class ClientReceiver : IReceiver
    {
        public Client client;
        public ClientReceiver(Client client)
        {
            this.client = client;
        }
        public void handlePackage(string message)
        {
            string[] data = Regex.Split(message, "``");

            Console.WriteLine(message);
            switch (data[0])
            {
                case "Question":

                    Window1.quizw.VraagContent = WebUtility.HtmlDecode(data[2]);
                    Window1.quizw.AnswerLeftDown = WebUtility.HtmlDecode(data[3]);
                    Window1.quizw.AnswerLeftUp = WebUtility.HtmlDecode(data[4]);
                    Window1.quizw.AnswerRightDown = WebUtility.HtmlDecode(data[5]);
                    Window1.quizw.AnswerRightUp = WebUtility.HtmlDecode(data[6]);

                    break;
                case "PlayerJoin":
                    //cr.playerNames.Add((string) data[1]);
                    break;
                case "PlayerLeave":
                    //cr.playerNames.Remove((string) data[1]);

                    break;
                case "ConnectionSuccesfull":
                    JoinWindow.joinw.joined = true;
                    break;
                case "Answer":
                    if(data[1] == "True")
                    {
                        Window1.quizw.score++;
                    }
                    client.SendQuestionRequest(Window1.quizw.roomcode);
                    break;
                case "Roomcode":
                    WaitRoom.waitr.roomcode = data[1];
                    break;
                case "Start":
                    WaitRoom.waitr.readyGame();
                    break;
            }
        }
    }
}
