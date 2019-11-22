using Microsoft.AspNet.Identity;
using miniproject.Interface;
using miniproject.Models;
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
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
        public ActionResult LoginView(Login login)
        {
            var log = dbContext.employees.FirstOrDefault(m => m.EmailId == login.UserName || m.SapId == login.UserName);
            if (log != null)
            {
                if (log.Password == login.Password &&(log.EmailId==login.UserName)||(log.SapId==login.UserName))
                {
                    loginrepositary.LoginValidation(login);
                    return RedirectToAction("SearchDoctor", "Patients");

                }
                else

                    return HttpNotFound();
            }
            else
                return Content("Data Not found");
        }
       
      
        public IEnumerable<SelectListItem> ListCity()
        {
            var loc = (from m in dbContext.locations.AsEnumerable()
                              select new SelectListItem
                              {
                                  Text = m.City,
                                  Value = m.LocationId.ToString()
                              }).ToList();
            loc.Insert(0, new SelectListItem { Text = "----select the type---", Value = "0", Disabled = true, Selected = true });
            return loc;
        }
    }
}



