using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewGangSim.GameElements.LocationElements
{
    public class Location
    {
        private uint locationID;
        private uint locationXOrigin;
        private uint locationYOrigin;
        private string locationName;
        private uint locationDefenseRatio;
        private uint locationAttackRatio;
        private uint locationProductionRatio;
        private string locationProduceKind;
        private List<House> houseList;

        public Location(uint locationXOrigin,uint locationYOrigin,uint locationID, string locationName, uint locationDefenseRatio, uint locationAttackRatio, uint locationProductionRatio, string locationProduceKind)
        {
            this.LocationID = locationID;
            this.LocationXOrigin = locationXOrigin;
            this.LocationYOrigin = locationYOrigin;
            this.LocationName = locationName;
            this.LocationDefenseRatio = locationDefenseRatio;
            this.LocationAttackRatio = locationAttackRatio;
            this.LocationProductionRatio = locationProductionRatio;
            this.LocationProduceKind = locationProduceKind;
            this.HouseList = new List<House>();
        }

        public uint LocationID { get => locationID; set => locationID = value; }
        public string LocationName { get => locationName; set => locationName = value; }
        public uint LocationDefenseRatio { get => locationDefenseRatio; set => locationDefenseRatio = value; }
        public uint LocationAttackRatio { get => locationAttackRatio; set => locationAttackRatio = value; }
        public uint LocationProductionRatio { get => locationProductionRatio; set => locationProductionRatio = value; }
        public string LocationProduceKind { get => locationProduceKind; set => locationProduceKind = value; }
        public uint LocationXOrigin { get => locationXOrigin; set => locationXOrigin = value; }
        public uint LocationYOrigin { get => locationYOrigin; set => locationYOrigin = value; }
        public List<House> HouseList { get => houseList; set => houseList = value; }
    } // Not sure if this is necessary, might be deleted later.
    //UPDATE : IT WAS NECESSARY
}
