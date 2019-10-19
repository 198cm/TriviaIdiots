using System;
using System.Collections.Generic;
using System.Text;
using TI_Server.Players;

namespace TI_Server
{
    class ServerRoom
    {

        public string roomName { get; set; }
        public List<Player> players { get; set; }

        public ServerRoom(string roomName)
        {
            this.roomName = roomName;
            this.players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void startRoom()
        {
            foreach(Player player in players)
            {
                player.client.Write("Start~_~");
            }
        }

    }
}
