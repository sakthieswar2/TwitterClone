using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterCloneApp.Models;
using TwitterCloneApp.DataAccess;
using System.Threading.Tasks;

namespace TwitterCloneApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            var result = DataAccessLayer.validateUser(model.userName, model.password);
            if (result.Count > 0)
            {
                var person = result.FirstOrDefault();

                Session["username"] = person.user_id;
                Session["fullname"] = person.fullname;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Signup(RegisterModel objRegisterUser)
        {
            var person = new person
            {
                fullname = objRegisterUser.fullname,
                email = objRegisterUser.email,
                password = objRegisterUser.password,
                user_id = objRegisterUser.username,
                active = true,
                joined = DateTime.Now
            };
            var result = await DataAccessLayer.createNewUser(person);
            if (result > 0)
            {
                Session["username"] = objRegisterUser.username;
                Session["fullname"] = objRegisterUser.fullname;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpGet]
        public JsonResult SearchUser(string username)
        {
            bool result = DataAccessLayer.isUserAvailable(username);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserProfile(string username)
        {
            person person = DataAccessLayer.getPersonDetails(username);
            return View(person);
        }
        public ActionResult Follow(string loginUserid, string followingserid)
        {
            var result = DataAccessLayer.followUser(loginUserid, followingserid);
            if (result)
                return RedirectToAction("Index","Home");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Signout()
        {
            Session["username"] = "";
            return RedirectToAction("Login", "Account");
        }
    }
}