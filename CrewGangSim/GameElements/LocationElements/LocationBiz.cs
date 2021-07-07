using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * LocationBiz class, has attributes for ID,Name,money,gunMaterials and drugs.
 */
namespace CrewGangSim.GameElements.LocationElements
{
    class LocationBiz
    {
        private uint locationID;
        private string locationName;
        private uint money;
        private uint gunMaterials;
        private uint heroin;
        private uint cocain;
        private uint lsd;
        private uint cannabis;
        private uint weed;


        public LocationBiz(uint locationID, string locationName)
        {
            this.LocationID = locationID;
            this.LocationName = locationName;
        }

        public uint LocationID { get => locationID; set => locationID = value; }
        public string LocationName { get => locationName; set => locationName = value; }
        public uint Money { get => money; set => money = value; }
        public uint GunMaterials { get => gunMaterials; set => gunMaterials = value; }
        public uint Heroin { get => heroin; set => heroin = value; }
        public uint Cocain { get => cocain; set => cocain = value; }
        public uint Lsd { get => lsd; set => lsd = value; }
        public uint Cannabis { get => cannabis; set => cannabis = value; }
        public uint Weed { get => weed; set => weed = value; }
    }
}
