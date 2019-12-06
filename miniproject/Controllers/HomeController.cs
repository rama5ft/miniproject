using Microsoft.AspNet.Identity;
using miniproject.Interface;
using miniproject.Models;
using miniproject.ViewModel;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace miniproject.Controllers
{
    public class HomeController : Controller
    {
        ILogin loginrepositary;

        public HomeController(ILogin loginrepositary)
        {
            this.loginrepositary = loginrepositary;

        }
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public HomeController()
        {

        }
        public ActionResult Index()
        {


            return View();
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult UpcomingEvents()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult LoginView()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginView(Login login)
        {
            var log = dbContext.employees.FirstOrDefault(m => m.EmailId == login.UserName || m.SapId == login.UserName);
            if (log != null)
            {
                Session["LogedUserID"] = log.EmailId.ToString();
                Session["LogedUserFullname"] = log.Name.ToString();

                if (log.Password == login.Password && (log.EmailId == login.UserName) || (log.SapId == login.UserName))
                {
                    loginrepositary.LoginValidation(login);
                    return RedirectToAction("AfterLogin", "Home");

                }
                else

                    return HttpNotFound();
            }
            else
                return View();
        }


      
        [HttpGet]
        public ActionResult AddEmployee()
        {
            var employee = new Employee();
            return View(employee);
        }
       
        [HttpPost]
      
        public ActionResult AddEmployee(Employee employeeFromView)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeFromView);
            }
            dbContext.employees.Add(employeeFromView);
            dbContext.SaveChanges();
            return RedirectToAction("Admin", "Home");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddDoctor()
        {
            var city = dbContext.locations.ToList();
            var viewmodel = new CommonViewModel()
            {
                Location = city
            };
            return View(viewmodel);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult AddDoctor(Doctor doctorFromView)
        {      
            dbContext.doctors.Add(doctorFromView);
            dbContext.SaveChanges();
            return RedirectToAction("Admin", "Home");
      
          
            
        }
        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult ListEmployee()
        {
            var emp = dbContext.employees.ToList();
            return View(emp);
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult ListDoctor()
        {
            var doc = dbContext.doctors.Include(c=>c.Location).ToList();
            return View(doc);
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult ViewAppointments()
        {
            var patients = dbContext.patients.Include(m => m.Doctor).Include(m => m.Slot).Include(c => c.Employee).ToList();
            if (patients != null)
            {
                return View(patients);
            }

            else
                return Content("No Appointments");
        }

        [ValidateAntiForgeryToken()]
        public ActionResult DeleteAppointmentDetails(int id)
        {
            var patientDel = dbContext.patients.SingleOrDefault(c => c.PatientId == id);

            if (patientDel != null)
            {

                ViewBag.SlotId = ListSlots();
                dbContext.patients.Remove(patientDel);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return HttpNotFound("Your Appointments Are Not Found");
        }

        [NonAction]
        public IEnumerable<SelectListItem> ListSlots()
        {
            var s = (from res in dbContext.slots.AsEnumerable()
                     select new SelectListItem
                     {
                         Text = res.TimeSlots,
                         Value = res.SlotId.ToString()
                     }).ToList();
            s.Insert(0, new SelectListItem { Text = "---select the Timeslot---", Value = "0", Disabled = false, Selected = false });
            return s;
        }

    }
}



