using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewGangSim.GameElements.UserElements
{
    public class User
    {
        //User attributes
        private string discordID;
        private string discordTag;

        public User(string discordID, string discordTag)
        {
            this.DiscordID = discordID;
            this.DiscordTag = discordTag;
        }

        public string DiscordID { get => discordID; set => discordID = value; }
        public string DiscordTag { get => discordTag; set => discordTag = value; }
    }
}