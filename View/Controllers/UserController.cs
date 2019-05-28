using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Models
{
    public class UserController : Controller
    {
        ActionResult LoginUser(UserDTO user)
        {
            return View();
        }
    }
}