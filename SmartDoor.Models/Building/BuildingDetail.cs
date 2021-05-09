
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Models.Building
{
    public class BuildingDetail
    {
        
        public int BuildingId { get; set; }
        
        public string BuildingName { get; set; }
       
        public string Address { get; set; }
        //public virtual DoorItemList Doors { get; set; }
       // public virtual ICollection<Door> Doors { get; set; }
      //  public virtual ICollection<SmartKey> SmartKeys { get; set; }
    }
}
