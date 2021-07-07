using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrewGangSim.GameElements.FactionElements
{
    public class Faction
    {
        private uint fID;
        private string fName;
        private uint fMoney;
        private uint fPoints;
        private uint fGunPoints;
        private uint fMemberSlot;
        public Faction(uint fID)
        {
            this.fID = fID;
        }//Temporary constructor for resultset.
        public Faction(uint fID, string fName, uint fMoney, uint fPoints, uint fGunPoints, uint fMemberSlot)
        {
            this.fID = fID;
            this.fName = fName;
            this.fMoney = fMoney;
            this.fPoints = fPoints;
            this.fGunPoints = fGunPoints;
            this.fMemberSlot = fMemberSlot;
        }
        public override string ToString()
        {
            return this.Fid + " " + this.Fname + " " + this.Fmoney + " " + this.Fpoints + " " + this.fGunPoints + " " + this.fMemberSlot + " ";
        }
        public uint Fstock { get => fGunPoints; set => fGunPoints = value; }
        public uint Fpoints { get => fPoints; set => fPoints = value; }
        public uint Fmoney { get => fMoney; set => fMoney = value; }
        public string Fname { get => fName; set => fName = value; }
        public uint Fid { get => fID; set => fID = value; }
        public uint Fmemberslot { get => fMemberSlot; set => fMemberSlot = value; }
    }
}
