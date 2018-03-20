using Microsoft.AspNet.Identity;
using PersonalTrainer.Models;
using PersonalTrainer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
            var imglist = _context.ImgPaths.Where(u => u.UserId == user.Id).ToList();
            user.UserImg = imglist;

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
            user.HeightFeet = userProfile.HeightFeet;
            user.HeightInches = userProfile.HeightInches;
            user.Weight = userProfile.Weight;
            user.Gender = userProfile.Gender;
            user.GoalWeight = userProfile.GoalWeight;
            user.ActivityLevel = userProfile.ActivityLevel;
            user.LastUpdate = DateTime.Today;

            ProfileUpdatesModels history = new ProfileUpdatesModels();
            history.UserId = user.Id;
            history.Age = userProfile.Age;
            history.Weight = userProfile.Weight;
            history.HeightFeet = userProfile.HeightFeet;
            history.HeightInches = userProfile.HeightInches;
            history.Gender = userProfile.Gender;
            history.GoalWeight = userProfile.GoalWeight;
            history.ActivityLevel = userProfile.ActivityLevel;
            history.DateOfLog = DateTime.Today;
            string bmiIndicator = "";

            decimal Height = (decimal.Parse(userProfile.HeightFeet) * 12) + decimal.Parse(userProfile.HeightInches);

            decimal bmi = (decimal.Parse(userProfile.Weight)) / (Height * Height) * 703;
            bmi = Math.Round(bmi * 100) / 100;
            if (bmi < 19)
            {
                bmiIndicator = "Underweight";
            }
            else if (bmi == 19 || bmi < 25)
            {
                bmiIndicator = "Healthy";
            }
            else if (bmi == 25 || bmi < 30)
            {
                bmiIndicator = "Overweight";
            }
            else if (bmi == 30 || bmi < 40)
            {
                bmiIndicator = "Obese";
            }
            else
            {
                @bmiIndicator = "Extremely Obese";
            }

            user.BMI = bmi.ToString();
            user.BmiIndicator = bmiIndicator;

            _context.ProfileHistory.Add(history);
            _context.SaveChanges();

            return RedirectToAction("Index", "ManageAccount");
        }

        public ActionResult UploadPicture(HttpPostedFileBase file)
        {
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();

            if (file != null)
            {
                string pic = Path.GetFileName(file.FileName);
                string path = "";

                try
                {
                    string userPath = Server.MapPath("~/ProfileImages/" + user.Id);

                    if (Directory.Exists(userPath))
                    {
                        path = Path.Combine(userPath, pic);
                    }
                    else
                    {
                        DirectoryInfo di = Directory.CreateDirectory(userPath);
                        path = Path.Combine(userPath, pic);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally { }

                file.SaveAs(path);
                

                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

                UserImgPathModel userImgPath = new UserImgPathModel();

                userImgPath.UserId = user.Id;
                userImgPath.Path = "~/ProfileImages/" + user.Id + "/" + pic;
                userImgPath.DateUploaded = DateTime.Today;

                _context.ImgPaths.Add(userImgPath);                
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "ManageAccount");
        }

        public ActionResult GoalsIndicator()
        {
            WeightViewModel weightVM = new WeightViewModel();
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            var beginingWeights = _context.ProfileHistory.Where(x => x.UserId == user.Id).First();
            List<string> listItemAdd = new List<string>() { beginingWeights.Weight };
            weightVM.Weight = listItemAdd;
            weightVM.User = user;

            return View(weightVM);
        }
    }
}