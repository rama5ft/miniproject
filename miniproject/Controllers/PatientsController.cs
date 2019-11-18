using miniproject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace miniproject.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public PatientsController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        // GET: Patients
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult locationView()
        {
            var loc = dbContext.locations.ToList();
            //var loc = dbContext.locations.Where(d => d.City==d.Area).ToList();
            return View(loc);

        }
    

        public ActionResult DoctorView(int id)
        {
            var docdet = dbContext.doctors.Include(m => m.Location).ToList().SingleOrDefault(a => a.Id == id);
            return View(docdet);
            
        } 
        
    }
}