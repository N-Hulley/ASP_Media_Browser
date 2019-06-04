using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class HomeController : Controller
    {
        public bool UserLoggedIn()
        {
            return Session["validUser"] != null;
        }
        public static string currentPage = "";
        public ActionResult Index()
        {
            currentPage = "Home";

            return View();
        }
        public ActionResult Search()
        {
            
            currentPage = "Search";
            ViewBag.Message = "Your Search page.";

            return UserLoggedIn() ? View() : View("index");
        }
        ControllerLayer.iUserManager UserManager = new ControllerLayer.UserManagerImp();

        public ActionResult Login(Models.UserDTO user)
        {
            ControllerLayer.UserDTO ValidUser;
            try
            {
                ValidUser = UserManager.ValidateUser(user.Username, user.Password);
                Session["LoginError"] = null;
                Session["validUser"] = ValidUser;
            }
            catch (Exceptions.DatabaseException e)
            {
                Session["LoginError"] = new Models.LoginError(e.Message);
                return View("Index");
            }
            catch (Exceptions.ValidationException e)
            {
                Session["LoginError"] = new Models.LoginError(e.Message);
                return View("Index");
            }
            return View("Index");
        }

        public ActionResult TestView()
        {
            ViewBag.Message = "Your Search page.";

            return View();
        }
        public ActionResult Signout()
        {
            Session.Clear();
            Session.Abandon();
            return View("Index");
        }
    }
}