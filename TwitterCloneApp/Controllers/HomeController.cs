using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterCloneApp.DataAccess;

namespace TwitterCloneApp.Controllers
{
    public class HomeController : Controller
    {
        
        //[Authorize]
        public ActionResult Index()
        {
            if (Session["username"].ToString() != "" && Session["username"] != null)
            {
                var username = Session["username"].ToString();
                var tvm = DataAccessLayer.getUserTweets(username);
                tvm.username = username;
                return View(tvm);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
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

        public ActionResult Update(tweet objTweet)
        {
            bool result;
            try
            {
                result = DataAccessLayer.saveUserTweet(objTweet);
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View(result);
        }

    }
}