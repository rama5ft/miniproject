using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniproject.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DocEmailId { get; set; }
        public string DocPassword { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }


        //Referncing foreign key
        public Location Location { get; set; }

        //add reference column
       
        public int? LocationId { get; set; }
    }
}