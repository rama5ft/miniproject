using miniproject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using miniproject.Interface;
using miniproject.ViewModel;
using Microsoft.Ajax.Utilities;

namespace miniproject.Controllers
{
    public class PatientsController : Controller
    {
        CommonInterface commonInterface;
        PatientDetails patientDetails;
       
        public PatientsController(CommonInterface commonInterface, PatientDetails patientDetails)
        {
            this.commonInterface = commonInterface;
            this.patientDetails = patientDetails;
        }
        ApplicationDbContext dbContext = new ApplicationDbContext();

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

       

        public ActionResult SearchDoctor(int? LocationId, string Specialization)
        {
            ViewBag.Locations = new SelectList(dbContext.locations.ToList(), "LocationId", "City");

            DoctorViewModel model = new DoctorViewModel();
            if (LocationId.HasValue)
            {
                ViewBag.Doctors = new SelectList(dbContext.doctors.Where(c => c.LocationId == LocationId).DistinctBy(x=>x.Specialization).ToList(), "Specialization", "Specialization");

            }

            if (LocationId.HasValue && !string.IsNullOrWhiteSpace(Specialization))
            {
                model.DoctorsList= dbContext.doctors.Include(c=>c.Location).Where(d=> d.Specialization == Specialization && d.LocationId == LocationId).ToList();

            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CreatePatientDetails(int DoctorId)
        {
            var p3 = new Patient();
            ViewBag.DoctorId = DoctorId;
            ViewBag.SlotId = ListSlots();
            return View(p3);
        }
        [HttpPost]
        public ActionResult CreatePatientDetails(Patient p1)
        {
          
            if (ModelState.IsValid)
            {
                var res = patientDetails.CreatePatient(p1);
                ViewBag.DoctorId = res.DoctorId;
                //ViewBag.SlotId = res.SlotId;
               // ViewBag.DoctorName = res.Doctor.DoctorName;
                ViewBag.SlotId = ListSlots();
                return View("PDetails",res);
            }
            return RedirectToAction("Index");
        }


        //public ActionResult SelectSlot()
        //{
        //    ViewBag.TimeSlots = ListSlots();
        //    return View();
        //}


        [NonAction]
        public IEnumerable<SelectListItem> ListSlots()
        {
            var s = (from res in dbContext.slots.AsEnumerable()
                     select new SelectListItem
                        { Text = res.TimeSlots ,
                           Value = res.SlotId.ToString()
                        }).ToList();
            s.Insert(0, new SelectListItem { Text = "---select the Timeslot---", Value = "0", Disabled = true, Selected = true });
            return s;
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListDoctorIds()
        {
            var s = (from res in dbContext.doctors.AsEnumerable()
                     select new SelectListItem
                     {
                         Text = res.DoctorId.ToString(),
                         Value = res.DoctorId.ToString()
                     }).ToList();
            s.Insert(0, new SelectListItem { Text = "---select the DoctorId---", Value = "0", Disabled = true, Selected = true });
            return s;
        }  
        public ActionResult List()
        {
            var customers = dbContext.patients.Include(m => m.Doctor).ToList();
            return View(customers);
          
        }
        public ActionResult PDetails(int PatientId)
        {

            var p = patientDetails.Details(PatientId);
            return View(p);
           
        }

    }
}




