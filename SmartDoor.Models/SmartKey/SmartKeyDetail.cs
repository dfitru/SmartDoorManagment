using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Models.SmartKey
{
   public class SmartKeyDetail
    {
        public int KeyId { get; set; }
        public string Name { get; set; }
        public bool KeyRecived { get; set; }
        
        public DateTimeOffset CreateDate { get; set; }

        public virtual PersonListItem Persons { get; set; }
        public virtual DoorItemList Doors { get; set; }
    }
}
