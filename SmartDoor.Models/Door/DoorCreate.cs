using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Models
{
    public class DoorCreate
    {
        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        public string DoorName { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        [Required]
        public bool IsRoomInRoom { get; set; }
        public int? BuildingId { get; set; }
       // public string BuildingName { get; set; }
        //public string Adress { get; set; }

        //private virtual Building Building { get; set; }

    }
}
