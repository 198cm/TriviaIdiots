using System;
using System.Collections.Generic;
using System.Text;

namespace TI_Server.Players
{
    class Player
    {
        public string name { get; set; }
        public ServerClient client { get; set; }

        public Player(ServerClient client, string name)
        {
            this.name = name;
            this.client = client;
        }


    }
}
