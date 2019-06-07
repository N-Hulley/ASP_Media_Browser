using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    
    public class HomeController : Controller
    {
        
        UserWSService.IUserLoginService LoginService = new UserWSService.UserLoginServiceImp();
        
        private System.Web.SessionState.HttpSessionState GetSession()
        {
            return System.Web.HttpContext.Current.Session;
        }
        public bool UserLoggedIn()
        {
           
            if (GetSession()["validUser"] != null) return true;
            return false;
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
            ViewBag.Message = "Search.";

            return UserLoggedIn() ? View() : View("index");
        }
        public ActionResult SearchMedia(Models.MediaDTO searchParameters)
        {
            currentPage = "Results";
            ViewBag.Message = "Your Search page.";

            return UserLoggedIn() ? View("Search") : View("index");
        }

        public ActionResult Login(Models.UserDTO user)
        {

            UserWSService.UserWSDTO ValidUser;
          
            try
            {                
                ValidUser = LoginService.ValidateUser(Translate(user));
                if (ValidUser.IsValid)
                {
                    Session["LoginError"] = null;
                    Session["validUser"] = ValidUser;
                } else
                {
                    throw new Exception(ValidUser.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                Session["LoginError"] = new Models.LoginError(e.Message);
            } 
            return View("Index");
        }

        public ActionResult TestView()
        {
            ViewBag.Message = "Your Search page.";

            return View();
        }
        
        private UserWSService.UserWSDTO Translate(View.Models.UserDTO user)
        {
            UserWSService.UserWSDTO Output = new UserWSService.UserWSDTO();
            Output.Username = user.Username;
            Output.Password = user.Password;
            return Output;
        }
        public ActionResult Signout()
        {
            Session.Clear();
            Session.Abandon();
            return View("Index");
        }
    }
}