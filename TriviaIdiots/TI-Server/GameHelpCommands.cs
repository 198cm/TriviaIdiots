using System;
using System.Collections.Generic;
using System.Text;

namespace TI_Server
{
    class GameHelpCommands
    {

        public static string RoomCodeGenerate()
        {
            StringBuilder Sbuilder = new StringBuilder();
            Random r = new Random();
            char ch;
            for (int i = 0; i < 4; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65)));
                Sbuilder.Append(ch);
            } 
                return Sbuilder.ToString().ToLower();     
        }
    }
}
