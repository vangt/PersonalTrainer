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

        public ActionResult ProfileInfo()
        {
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();

            return View(user);
        }
    }
}