using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace miniproject.Models
{
    public class Patient
    {
       [Key]
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string SapId { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }
       
      //  [DataType(DataType.Date)] 
        public string Date { get; set; }
                                           //Addding reference tables
        public Doctor Doctor { get; set; }
        public int? DoctorId { get; set; }
        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }
        public Slot Slot { get; set; }
        public int? SlotId { get; set; }




    }
}