
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Models
{
    public class PersonDetail
    {
        [Key]
        public int KeyOwenerId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        [Required]
        public string Company { get; set; }
        // public virtual SmartKey SmartKeys { get; set; }
       // public ICollection<SmartKey> SmartKeys { get; set; }

    }
}
