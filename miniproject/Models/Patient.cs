using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniproject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string SapId { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }
      
    }
}