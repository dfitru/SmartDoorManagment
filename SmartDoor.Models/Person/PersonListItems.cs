using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDoor.Models
{
    public class KeyOwnerListItems
    {
       
        public int KeyOwenerId { get; set; }
       
      
        public string FirstName { get; set; }
       
        
        public string LastName { get; set; }
    
       
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
