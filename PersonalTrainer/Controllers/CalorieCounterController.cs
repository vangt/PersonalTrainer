using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PersonalTrainer.Models;
using PersonalTrainer.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
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
            var foodList = _context.FoodInput.Where(x => x.UserId == user.Id).ToList();

            calorieCounter.User = user;
            calorieCounter.Foodlist = foodList;

            return View(calorieCounter);
        }

        public ActionResult CaloricChart()
        {
            CalorieCounterViewModel calories = new CalorieCounterViewModel();
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            var foodList = _context.FoodInput.Where(x => x.UserId == user.Id).ToList();
            calories.User = user;
            calories.Foodlist = foodList;


            return View(calories);
        }

        public ActionResult InputFood()
        {
            SearchCaloriesViewModel search = new SearchCaloriesViewModel();

            return View(search);
        }

        [HttpPost]
        public ActionResult InputFood(SearchCaloriesViewModel search)
        {
            var searchItem = search.SearchWordInput;
            var foodApi = UsdaCall(searchItem);
            search.FoodApi = foodApi;

            return View(search);
        }

        public FoodAPI UsdaCall(string search)
        {
            FoodAPI foodList = new FoodAPI();
            var wordString = search.Split(' ');
            string searchWord = string.Join("_", wordString);
            string url = "https://api.nal.usda.gov/ndb/search/?format=json&q=" + searchWord + "&sort=n&max=25&offset=0&api_key=0z1GpkjkpfVWgsun2yHlxCBg4Oy7hFUUBJ3wLu2j";
                    
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "f9ebf779-b062-fa61-265c-808806ca98de");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            var results = JsonConvert.DeserializeObject<FoodAPI>(response.Content);
            foodList = results;

            return foodList;
        }

        public ActionResult AddItem(string id)
        {
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            FoodItemApi foodItem = new FoodItemApi();
            FoodInputModels foodInput = new FoodInputModels();

            string itemId = id;
            string url = "https://api.nal.usda.gov/ndb/nutrients/?format=json&api_key=0z1GpkjkpfVWgsun2yHlxCBg4Oy7hFUUBJ3wLu2j&nutrients=204&nutrients=203&nutrients=205&ndbno=" + id;

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "e29cf453-ed2b-3dbe-3c1a-9214d60fbc73");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            var results = JsonConvert.DeserializeObject<FoodItemApi>(response.Content);
            foodItem = results;

            FoodInputModels itemNutrient = new FoodInputModels();
            itemNutrient.FoodName = foodItem.Report.Foods[0].Name;
            itemNutrient.FoodId = foodItem.Report.Foods[0].Ndbno;
            itemNutrient.UserId = user.Id;
            itemNutrient.DateAdded = DateTime.Today;
            itemNutrient.Weight = foodItem.Report.Foods[0].Weight.ToString();
            itemNutrient.Measure = foodItem.Report.Foods[0].Measure;

            var test = results.Report.Foods[0].Nutrients;
            foreach (var item in test)
            {
                
                if(item.NutrientId == "203")
                {
                    itemNutrient.Protien = Math.Round(double.Parse(item.Value)).ToString() + " " + item.Unit;
                }
                else if(item.NutrientId == "204")
                {
                    itemNutrient.Fat = Math.Round(double.Parse(item.Value)).ToString() + " " + item.Unit;
                }
                else if(item.NutrientId == "205")
                {
                    itemNutrient.Carb = Math.Round(double.Parse(item.Value)).ToString() + " " + item.Unit;
                }
            }

            _context.FoodInput.Add(itemNutrient);
            _context.SaveChanges();
            
            return RedirectToAction("InputedItem", "CalorieCounter");
        }

        public ActionResult InputedItem()
        {
            return View();
        }
    }
}