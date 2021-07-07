using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrewGangSim.GameElements.FactionElements;

namespace CrewGangSim.GameElements.UserElements
{
    //TODO health of player.
    public class Player : User
    {
        private uint experience;
        private uint money;
        private uint factionID;
        public Player(string discordID, string discordTag) : base(discordID, discordTag)
        {
            this.Experience = 1;
            this.Money = 500;
        }

        public uint Experience { get => experience; set => experience = value; }
        public uint Money { get => money; set => money = value; }
        public uint FactionID { get => factionID; set => factionID = value; }
    }
}