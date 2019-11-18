using miniproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var log =dbContext.employees.SingleOrDefault(m => m.EmailId==login.EmailId && m.SapId == login.SapId);
           if(log.Password== login.Password)
            {
                loginrepositary.LoginValidation(login);
                return RedirectToAction("locationView","Patients");

            }
           else

            return View();
        }
    }
}