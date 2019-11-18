using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniproject.Models
{
    public class Login
    {
        public int id { get; set; }
        public string EmailId { get; set; }
        public string SapId { get; set; }
        public string Password { get; set; }
    }
}