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
                    cr.VraagCat = data[1];
                    cr.VraagContent = data[2];
                    cr.AnswerLeftDown = data[3];
                    cr.AnswerLeftUp = data[4];
                    cr.AnswerRightDown = data[5];
                    cr.AnswerRightUp = data[6];
                    Window1.quizw.VraagContent = data[2];
                    Window1.quizw.AnswerLeftDown = data[3];
                    Window1.quizw.AnswerLeftUp = data[3];
                    Window1.quizw.AnswerRightDown = data[3];
                    Window1.quizw.AnswerRightUp = data[3];

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
                    WaitRoom.waitr.readyGame();
                    break;
            }
        }
    }
}
