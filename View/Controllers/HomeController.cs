using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace View.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserWSService.IUserLoginService LoginService = new UserWSService.UserLoginServiceImp();
        private readonly MediaService.IMediaService MediaManager = new MediaService.MediaServiceImp();
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
            return View("index");
        }
        public ActionResult Search()
        {

            currentPage = "Search";
            ViewBag.Message = "Search.";

            return UserLoggedIn() ? View(new Models.MediaDTO()) : Index();
        }
        public ActionResult SearchMedia(Models.MediaDTO searchParameters)
        {
            currentPage = "Results";
            ViewBag.Message = "Your Search page.";
            if (!UserLoggedIn())
            {
                return Index();
            }
            if (searchParameters != null)
            Session["SearchResults"] = MediaManager.MakeQuery(
                GetUser(),
                searchParameters.Title,
                searchParameters.Genre,
                searchParameters.Director,
                searchParameters.Language,
                searchParameters.Year
                );
            return View("SearchResults");
        }
        public ActionResult SearchResults()
        {
            return SearchMedia(new Models.MediaDTO());
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
                    if (ValidUser.UserLevel >= 3)
                    {
                        return Admin();
                    }
                }
                else
                {
                    throw new Exception(ValidUser.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                Session["LoginError"] = new Models.LoginError(e.Message);
            }
            return Index();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Register an account";

            return View("Register");
        }
        public ActionResult RegisterAccount(View.Models.UserDTO user)
        {
            try
            {
                LoginService.RegisterNewUser(Translate(user));
                return Login(user);
            } catch (Exception e)
            {
                Session["RegisterError"] = new View.Models.LoginError(e.Message);
                return View("Register");
            }

        }
        private UserWSService.UserWSDTO Translate(View.Models.UserDTO user)
        {
            UserWSService.UserWSDTO Output = new UserWSService.UserWSDTO();
            if (user.Username != null && user.Password != null)
            {
                Output.Username = user.Username;
                Output.Password = user.Password;
                return Output;
            }
            else
            {
                throw new Exception("Username or password was not given");
            }
        }

        public ActionResult Signout()
        {
            Session.Clear();
            Session.Abandon();
            return Index();
        }
        private UserWSService.UserWSDTO GetUser()
        {
            UserWSService.UserWSDTO user;
            try
            {
                if (UserLoggedIn())
                {
                    user = (UserWSService.UserWSDTO)(Session["ValidUser"]);
                    return user;
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return null;

        }
        public bool IsAdmin()
        {
            UserWSService.UserWSDTO user = GetUser();
            if (user == null) return false;
            if (user.UserLevel.HasValue && user.UserLevel >= 3)
            {
                return true;
            }
            return false;
        }
        public ActionResult Admin()
        {
            if (IsAdmin())
            {
                currentPage = "Admin";
                ViewBag.Message = "Admin";
                return View("Admin");
            }
            return Index();
        }
        public ActionResult UserList()
        {
            if (IsAdmin())
            {
                currentPage = "User List";
                ViewBag.Message = "User List";
                return View("UserList");
            }
            return Index();
        }
        public JsonResult ChangeMedia(string command, string MID)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            result.Add("Success", false);
            result.Add("Affected", null);
            if (IsAdmin())
            {
                int mediaID;
                if (Int32.TryParse(MID, out mediaID))
                {
                    UserWSService.UserWSDTO user = GetUser();
                    MediaService.MediaWSDTO media = MediaManager.getMediaByID(user, mediaID);
                    result["Affected"] = media;
                    if (command == "EDIT")
                    {
                        return AddMedia(media);
                    }
                    else if (command == "DELETE")
                    {
                        MediaManager.DeleteMedia(user, media);
                    }
                }
                result["Success"] = true;
                return Json(result);
            }

            return Json(result);
        }
        public JsonResult AddMedia(MediaService.MediaWSDTO media)
        {
            if (IsAdmin())
            {
                try
                {
                    return Json(MediaManager.getMediaByID(GetUser(),(MediaManager.AddMedia(GetUser(), media)).MediaID));
                } catch (Exception e)
                {
                    return Json(e.Message);
                }
            }
            return Json("User not admin");

        }
        public ActionResult EditMedia(MediaService.MediaWSDTO media)
        {
            if (IsAdmin())
            {

            }
            return Index();
        }
        public JsonResult GetDirectors()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            result["Response"] = MediaManager.GetDirectors(GetUser());
            return Json(result);
        }
        public JsonResult GetGenres()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            result["Response"] = MediaManager.GetGenres(GetUser());
            return Json(result);
        }
        public JsonResult GetLanguages()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            result["Response"] = MediaManager.GetLanguages(GetUser());
            return Json(result);
        }
        public JsonResult GetUsers()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            result["Response"] = LoginService.GetUsers(GetUser());
            return Json(result);
        }
        public ActionResult Directors()
        {
            if (IsAdmin())
            {
                return View("Directors");
            }
            return Index();
        }
        public ActionResult Genres()
        {
            if (IsAdmin())
            {
                return View("Genres");
            }
            return Index();
        }
        public ActionResult Languages()
        {
            if (IsAdmin())
            {
                return View("Languages");
            }
            return Index();
        }

        public JsonResult AddField(string name, string currentType)
        {
            if (IsAdmin())
            {
                IDictionary<string, object> result = new Dictionary<string, object>();
                result.Add("Affected", null);
                try
                {
                    switch (currentType)
                    {
                        case "director": result["Affected"] = (MediaManager.GetDirectors(GetUser(), MediaManager.AddDirector(GetUser(), name))); break;
                        case "genre": result["Affected"] = (MediaManager.GetGenres(GetUser(), MediaManager.AddGenre(GetUser(), name))); break;
                        case "language": result["Affected"] = (MediaManager.GetLanguages(GetUser(), MediaManager.AddLanguage(GetUser(), name))); break;
                    }
                }
                catch (Exception e)
                {
                    return Json(e.Message);
                }
                return Json(result);
            }
            return Json("User not admin");

        }
        public JsonResult ChangeOtherField(string command, string ID, string currentType)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            result.Add("Success", false);
            result.Add("Affected", null);
            if (IsAdmin())
            {
                try
                {
                    int currentID;
                    if (Int32.TryParse(ID, out currentID))
                    {
                        UserWSService.UserWSDTO user = GetUser();
                        switch (currentType)
                        {
                            case "director": result["Affected"] = MediaManager.GetDirectors(user, currentID); break;
                            case "genre": result["Affected"] = MediaManager.GetGenres(user, currentID); break;
                            case "language": result["Affected"] = MediaManager.GetLanguages(user, currentID); break;
                            case "user": result["Affected"] = LoginService.GetUsers(user, currentID); break;
                        }

                        if (command == "EDIT")
                        {
                            return null;
                        }
                        else if (command == "DELETE")
                        {
                            switch (currentType)
                            {
                                case "director": result["Success"] = MediaManager.DeleteDirector(user, currentID); break;
                                case "genre": result["Success"] = MediaManager.DeleteGenre(user, currentID); break;
                                case "language": result["Success"] = MediaManager.DeleteLanguage(user, currentID); break;
                                case "user": result["Success"] = LoginService.DeleteUser(user, currentID); break;
                            }
                        }
                    }
                    result["Success"] = true;
                    return Json(result);

                } catch (Exception e)
                {
                    result["Success"] = false;
                    return Json(result);
                }
                
            }

            return Json(result);
        }
    }
}