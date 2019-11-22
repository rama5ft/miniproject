using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace miniproject.Models
{
    public class Slot
    {
        [Key]
      public int SlotId { get; set; }
     
    
        public string TimeSlots { get; set; }
        //Reference table
       //public Doctor Doctor { get; set; }
       // //Reference Column
       // public int? DoctorId { get; set; }
    }
}