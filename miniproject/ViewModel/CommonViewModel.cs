using miniproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace miniproject.ViewModel
{
    public class CommonViewModel
    {
       public IEnumerable<Location> Location { get; set; }
        public Doctor Doctor { get; set; } 
        public Patient Patient { get; set; }
        public Slot slot { get; set; }
        
      
    }
}