﻿using Microsoft.AspNet.Identity;
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
            CalorieCounterViewModel calorie = new CalorieCounterViewModel();
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            var foodList = _context.FoodInput.Where(x => x.UserId == user.Id).ToList();
            calorie.User = user;
            calorie.Foodlist = foodList;

            return View(calorie);
        }

        public ActionResult CaloricChart(FoodInputModels foodList)
        {
            var Chart = new ChartViewModel();
            
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            var foodListItems = _context.FoodInput.Where(x => x.UserId == user.Id).ToList();

            List<double> caloric = new List<double>();
            List<string> addedDates = new List<string>();

            foreach (var item in foodListItems)
            {
                var cal = (double.Parse(item.Protien) * 4) + (double.Parse(item.Carb) * 4) + (double.Parse(item.Fat) * 9);
                var dateAdded = item.DateAdded.Value.ToString("MM/dd/yyyy");
                caloric.Add(cal);
                addedDates.Add(dateAdded);
            }

            Chart.DateAdded = addedDates;
            Chart.Calories = caloric;

            return View(Chart);
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
            var searchString = search.Trim();
            var wordString = searchString.Split(' ');
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
                    itemNutrient.Protien = Math.Round(double.Parse(item.Value)).ToString();
                }
                else if(item.NutrientId == "204")
                {
                    itemNutrient.Fat = Math.Round(double.Parse(item.Value)).ToString();
                }
                else if(item.NutrientId == "205")
                {
                    itemNutrient.Carb = Math.Round(double.Parse(item.Value)).ToString();
                }
            }

            var cal = (double.Parse(itemNutrient.Protien) * 4) + (double.Parse(itemNutrient.Carb) * 4) + (double.Parse(itemNutrient.Fat) * 9);

            itemNutrient.Calories = cal.ToString();

            _context.FoodInput.Add(itemNutrient);
            _context.SaveChanges();
            
            return RedirectToAction("InputedItem", "CalorieCounter");
        }

        public ActionResult InputedItem()
        {
            return View();
        }

        public ActionResult ViewItem(string id)
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

            return View(foodItem);
        }

        public ActionResult InputDetails()
        {
            FoodInputModels foodItem = new FoodInputModels();
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            foodItem.UserId = user.Id;

            return View(foodItem);
        }

        public ActionResult InputDeatil(FoodInputModels foodItem)
        {
            FoodInputModels item = new FoodInputModels();
            item.FoodName = foodItem.FoodName;
            item.Calories = foodItem.Calories;
            item.Fat = foodItem.Fat;
            item.Carb = foodItem.Carb;
            item.Protien = foodItem.Protien;
            item.DateAdded = DateTime.Today;
            item.UserId = foodItem.UserId;

            return RedirectToAction("InputedItem", "CalorieCounter");
        }

        public ActionResult RemoveItem(int id)
        {
            FoodInputModels item = _context.FoodInput.Where(x => x.Id == id).First();
            _context.FoodInput.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index", "CalorieCounter");
        }
    }
}