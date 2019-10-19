using System;
using System.Collections.Generic;
using System.Text;

namespace TI_Server
{
    public class ClientRoom
    {
        public List<string> playerNames { get; set; }
        public int roundNumber { get; set; }
        public string roomcode;

        public ClientRoom()
        {
            this.playerNames = new List<string>();
            roundNumber = 1;
            roomcode = "xxxx";
        }
    }
}
