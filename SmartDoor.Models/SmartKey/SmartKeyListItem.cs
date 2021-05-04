using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Models
{
    public class SmartKeyListItem
    {
        
        public int KeyId { get; set; }
        public string Name { get; set; }
        public bool KeyRecived { get; set; }
        public DateTime CreateDate { get; set; }
        public int? KeyOwnerId { get; set; }
        public int? DoorId { get; set; }
    }
}
