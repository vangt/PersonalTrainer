using Microsoft.AspNet.Identity;
using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalTrainer.Controllers
{
    public class ManageAccountController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: ManageAccount
        public ActionResult Index()
        {
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();

            return View(user);
        }

        public ActionResult UserInfo()
        {
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();

            return View();
        }

        public ActionResult ProfileInfo()
        {
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            List<string> activityLevel = new List<string>() { "No Activity", "Low Activity", "Moderately Activity", "High Activity" };
            user.ActivityList = activityLevel;

            return View(user);
        }
    }
}