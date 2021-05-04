using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Models
{
    public class SmartDoorItemList
    {
        public int DoorId { get; set; }
        
        public string DoorName { get; set; }
        
        public int FloorNumber { get; set; }
        
        public bool IsRoomInRoom { get; set; }
     
        public int? BuildingId { get; set; }
        public string BuildingName { get; set; }
        
        public string Address { get; set; }

    }
}
