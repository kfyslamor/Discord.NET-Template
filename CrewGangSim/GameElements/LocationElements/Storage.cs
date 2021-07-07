using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewGangSim.GameElements.LocationElements
{
    public class Storage
    {
        private int storageID;
        private uint dirtyMoney;
        private uint gunMaterials;
        private uint heroin;
        private uint cocain;
        private uint lsd;
        private uint weed;

        public Storage(int storageID, uint dirtyMoney, uint gunMaterials, uint heroin, uint cocain, uint lsd, uint weed)
        {
            this.storageID = storageID;
            this.dirtyMoney = dirtyMoney;
            this.gunMaterials = gunMaterials;
            this.heroin = heroin;
            this.cocain = cocain;
            this.lsd = lsd;
            this.weed = weed;
        }

        public int StorageID { get => storageID; set => storageID = value; }
        public uint DirtyMoney { get => dirtyMoney; set => dirtyMoney = value; }
        public uint GunMaterials { get => gunMaterials; set => gunMaterials = value; }
        public uint Heroin { get => heroin; set => heroin = value; }
        public uint Cocain { get => cocain; set => cocain = value; }
        public uint Lsd { get => lsd; set => lsd = value; }
        public uint Weed { get => weed; set => weed = value; }

        public override string ToString()
        {
            return $"{{{nameof(StorageID)}={StorageID.ToString()}, {nameof(DirtyMoney)}={DirtyMoney.ToString()}, {nameof(GunMaterials)}={GunMaterials.ToString()}, {nameof(Heroin)}={Heroin.ToString()}, {nameof(Cocain)}={Cocain.ToString()}, {nameof(Lsd)}={Lsd.ToString()}, {nameof(Weed)}={Weed.ToString()}}}";
        }
    }
}
