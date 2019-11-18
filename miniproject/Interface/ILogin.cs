using miniproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniproject
{
   public interface ILogin
    {
        Login LoginValidation(Login login);
    }
}
