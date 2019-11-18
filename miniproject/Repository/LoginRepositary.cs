using miniproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniproject.Repository
{
    public class LoginRepositary : ILogin
    {
        private ApplicationDbContext dbContext = null;
        public LoginRepositary()
        {
            dbContext = new ApplicationDbContext();
        }

        public Login LoginValidation(Login login)
        {
            var log = new Login
            {
                EmailId = login.EmailId,
                Password = login.Password,
                SapId = login.SapId
            };
            dbContext.Logins.Add(log);
            dbContext.SaveChanges();

            return log;

        }
    }
}