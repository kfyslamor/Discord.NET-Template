using CrewGangSim.GameElements.LocationElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewGangSim.GameElements.LocationElements
{
    public class House
    {
        private uint houseID;
        private string houseName;
        private Storage storage;
        public House()
        {
            this.houseName = null;
            this.storage = new Storage(0,0,0,0,0,0,0);
            //Constructing the storage temporarily, so we can later change the values regarding that.
        }
        public House(uint houseID, string houseName)
        {
            this.houseID = houseID;
            this.houseName = houseName;
            this.storage = new Storage(0, 0, 0, 0, 0, 0, 0); ;
        }//Classic constructor.

        public House(uint houseID, string houseName,Storage storage)
        {
            this.houseID = houseID;
            this.houseName = houseName;
            this.storage = storage;
        }//ResultSet constructor.

        public uint HouseID { get => houseID; set => houseID = value; }
        public string HouseName { get => houseName; set => houseName = value; }
        public Storage Storage { get => storage; set => storage = value; }

        public override string ToString()
        {
            return $"{{{nameof(HouseID)}={HouseID.ToString()}, {nameof(HouseName)}={HouseName}, {nameof(Storage)}={Storage}}}";
        }
    }
}
