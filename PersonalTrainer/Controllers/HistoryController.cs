using Microsoft.AspNet.Identity;
using PersonalTrainer.Models;
using PersonalTrainer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PersonalTrainer.Controllers
{
    public class HistoryController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: History
        public ActionResult Index()
        {
            HistoryViewModel historyVM = new HistoryViewModel();
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            var profiles = _context.ProfileHistory.Where(x=>x.UserId == user.Id).ToList();
            historyVM.User = user;
            historyVM.ProfileList = profiles;


            return View(historyVM);
        }

        public ActionResult WeightChart()
        {
            WeightViewModel weightVM = new WeightViewModel();
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            var weights = _context.ProfileHistory.Where(x => x.UserId == user.Id).ToList();
            List<string> weight = new List<string>();
            List<DateTime?> dates = new List<DateTime?>();
            
            foreach(var item in weights)
            {
                dates.Add(item.DateOfLog);
                weight.Add(item.Weight);
            }

            weightVM.Weight = weight;
            weightVM.DateAdded = dates;

            return View(weightVM);
        }
    }
}