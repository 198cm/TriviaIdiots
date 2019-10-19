using System;
using System.Collections.Generic;
using System.Text;

namespace TI_Server
{
    public class ClientRoom
    {
        public List<string> playerNames { get; set; }
        public int roundNumber { get; set; }
        public string roomcode { get; set; }
        public string VraagContent { get; set; } = "Nog vraag!";
        public string AnswerLeftUp { get; set; } = "-";
        public string AnswerLeftDown { get; set; } = "-";
        public string AnswerRightUp { get; set; } = "-";
        public string AnswerRightDown { get; set; } = "-";
        public string VraagCat { get; set; } = "";

        public ClientRoom()
        {
            this.playerNames = new List<string>();
            roundNumber = 1;
            roomcode = "xxxx";
        }
    }
}
