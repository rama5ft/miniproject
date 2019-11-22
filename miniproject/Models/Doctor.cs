using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace miniproject.Models
{
    public class Doctor
    {
       [Key]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DocEmailId { get; set; }
        public string DocPassword { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public bool Availability { get; set; }
        public string HospitalAddress { get; set; }
        public string HospitalName { get; set; }


        //Referncing foreign key
        public Location Location { get; set; }

        //add reference column
       
        public int? LocationId { get; set; }
        //Reference Table
        //public Specialization Specialization { get; set; }
        ////Refernce Column
        //public int? SpecializationId { get; set; }
    }
}