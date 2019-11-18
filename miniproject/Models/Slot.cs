using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniproject.Models
{
    public class Slot
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string TimeSlots { get; set; }
    }
}