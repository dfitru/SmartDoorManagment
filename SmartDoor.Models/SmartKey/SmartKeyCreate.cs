using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Models
{
    public class SmartKeyCreate
    {
        [Key]
        public int KeyId { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        public bool KeyRecived { get; set; }
        public int? KeyOwnerId { get; set; }
        public int? DoorId { get; set; }
  
    }
}
