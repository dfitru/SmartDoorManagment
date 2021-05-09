using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Data
{
   public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [Display(Name = "First Name"), MinLength(2, ErrorMessage = "please enter at lest 2 characters"), MaxLength(100, ErrorMessage = "There are too many characters")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name"), MinLength(2, ErrorMessage = "please enter at lest 2 characters"), MaxLength(100, ErrorMessage = "There are too many characters")]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string Company { get; set; }
        // public virtual SmartKey SmartKeys { get; set; }
        //public ICollection<SmartKey> SmartKeys { get; set; }

    }
}
