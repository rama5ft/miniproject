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
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string SapId { get; set; }
        [Required]
        public int Age { get; set; }
        [Required] 
        public string MobileNumber { get; set; }

        //  [DataType(DataType.Date)] 
        [Required]
        public string Date { get; set; }
        //Addding reference tables
        public Doctor Doctor { get; set; }
        public int? DoctorId { get; set; }
        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }
       
        public Slot Slot { get; set; }
        [Required]
        public int? SlotId { get; set; }

      


    }
}