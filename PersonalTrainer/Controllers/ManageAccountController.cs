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
            PersonalInfoUpdaterViewModel viewmodel = new PersonalInfoUpdaterViewModel();
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            viewmodel.User = user;


            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult UserInfo(PersonalInfoUpdaterViewModel userInfo)
        {
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();

            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.Address = userInfo.Address;
            user.City = userInfo.City;
            user.State = userInfo.State;
            user.Zip = userInfo.Zip;
            user.Phone = userInfo.Phone;

            _context.SaveChanges();

            return RedirectToAction("Index", "ManageAccount");
        }

        public ActionResult ProfileInfo()
        {
            ProfileUpdaterViewModel profile = new ProfileUpdaterViewModel();
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            List<string> activityLevel = new List<string>() { "No Activity (workout 0 days a week)", "Low Activity (workout 1-2 days a week)", "Moderately Activity (workout 3-4 days a week)", "High Activity (workout 5 or more days a week)" };
            List<string> genders = new List<string> { "Male", "Female" };
            user.ActivityList = activityLevel;
            user.GenderList = genders;

            profile.User = user;

            return View(profile);
        }

        [HttpPost]
        public ActionResult ProfileInfo(ProfileUpdaterViewModel userProfile)
        {
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();

            user.Age = userProfile.Age;
            user.Height = userProfile.Height;
            user.Weight = userProfile.Weight;
            user.Gender = userProfile.Gender;
            user.ActivityLevel = userProfile.ActivityLevel;
            user.LastUpdate = DateTime.Today;

            _context.SaveChanges();

            return RedirectToAction("Index", "ManageAccount");
        }
    }
}