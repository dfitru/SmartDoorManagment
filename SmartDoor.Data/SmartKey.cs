using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Data
{
   public class SmartKey
    {
        [Key]
        public int KeyId { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        public bool KeyRecived { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}")]
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }

        [ForeignKey(nameof(Person))]
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }
        [ForeignKey(nameof(SmartDoor))]
        public int? DoorId { get; set; }
        public virtual Door Door { get; set; }
    }
}
