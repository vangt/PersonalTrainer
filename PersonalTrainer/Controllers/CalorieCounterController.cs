using Microsoft.AspNet.Identity;
using PersonalTrainer.Models;
using PersonalTrainer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalTrainer.Controllers
{
    public class CalorieCounterController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: CalorieCounter
        public ActionResult Index()
        {
            CalorieCounterViewModel calorieCounter = new CalorieCounterViewModel();
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            var foodList = 0;

            calorieCounter.User = user;

            return View();
        }
    }
}