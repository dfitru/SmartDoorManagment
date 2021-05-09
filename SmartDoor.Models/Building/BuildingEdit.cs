using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Models.Building
{
    public class BuildingEdit
    {
        [Required]
        public int BuildingId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string BuildingName { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
