using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PersonalTrainer.Models;
using PersonalTrainer.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalTrainer.Controllers
{
    public class ExerciseController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Exercise
        public ActionResult Index()
        {
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            ExerciseHistroyViewModel history = new ExerciseHistroyViewModel();
            history.ExerciseHistory = _context.ExerciseHistory.Where(x => x.UserId == user.Id).ToList();

            return View(history);
        }

        public ActionResult AddExercise()
        {
            SearchExerciseViewModel searchExerciseVM = new SearchExerciseViewModel();
            Dictionary<string, string> muscles = new Dictionary<string, string>();
            muscles.Add("1", "Biceps");
            muscles.Add("2", "Deltoids");
            muscles.Add("3", "Serratus");
            muscles.Add("4", "Pectoralis");
            muscles.Add("5", "Triceps");
            muscles.Add("6", "Abs");
            muscles.Add("7", "Gastrocnemius");
            muscles.Add("8", "Gluteus Maximus");
            muscles.Add("9", "Trapezius");
            muscles.Add("10", "Quadriceps");
            muscles.Add("11", "Biceps Femoris");
            muscles.Add("12", "Latissimus");
            muscles.Add("13", "Brachialis");
            muscles.Add("14", "Obliquus");
            muscles.Add("15", "Soleus");

            searchExerciseVM.Muscles = muscles;

            return View(searchExerciseVM);
        }

        [HttpPost]
        public ActionResult AddExercise(SearchExerciseViewModel search)
        {
            ExerciseAPI exerciseAPI = new ExerciseAPI();
            exerciseAPI = WgerCall(search.SearchMuscle);

            SearchExerciseViewModel searchVM = new SearchExerciseViewModel();
            searchVM.ExerciseAPIs = exerciseAPI;

            Dictionary<string, string> muscles = new Dictionary<string, string>();
            muscles.Add("1", "Biceps");
            muscles.Add("2", "Deltoids");
            muscles.Add("3", "Serratus");
            muscles.Add("4", "Pectoralis");
            muscles.Add("5", "Triceps");
            muscles.Add("6", "Abs");
            muscles.Add("7", "Gastrocnemius");
            muscles.Add("8", "Gluteus Maximus");
            muscles.Add("9", "Trapezius");
            muscles.Add("10", "Quadriceps");
            muscles.Add("11", "Biceps Femoris");
            muscles.Add("12", "Latissimus");
            muscles.Add("13", "Brachialis");
            muscles.Add("14", "Obliquus");
            muscles.Add("15", "Soleus");

            searchVM.Muscles = muscles;

            return View(searchVM);
        }

        public ExerciseAPI WgerCall(string search)
        {
            ExerciseAPI exerciseAPI = new ExerciseAPI();
            Dictionary<string, string> muscles = new Dictionary<string, string>();
            muscles.Add("1", "Biceps");
            muscles.Add("2", "Deltoids");
            muscles.Add("3", "Serratus");
            muscles.Add("4", "Pectoralis");
            muscles.Add("5", "Triceps");
            muscles.Add("6", "Abs");
            muscles.Add("7", "Gastrocnemius");
            muscles.Add("8", "Gluteus Maximus");
            muscles.Add("9", "Trapezius");
            muscles.Add("10", "Quadriceps");
            muscles.Add("11", "Biceps Femoris");
            muscles.Add("12", "Latissimus");
            muscles.Add("13", "Brachialis");
            muscles.Add("14", "Obliquus");
            muscles.Add("15", "Soleus");

            var searchword = "";

            foreach(var muscle in muscles)
            {
                if(muscle.Value == search)
                {
                    searchword = muscle.Key;
                }
            }

            var client = new RestClient("https://wger.de/api/v2/exercise/?muscles=" + searchword + "&language=2");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "18bf030f-8e5b-e844-dbf6-d67d07d608cd");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            var json = JsonConvert.DeserializeObject<ExerciseAPI>(response.Content);
            exerciseAPI = json;

            return exerciseAPI;
        }

        public ActionResult AddEx(string id)
        {
            var userName = User.Identity.GetUserName();
            var user = _context.Users.Where(x => x.UserName == userName).First();
            
            ExerciseModels choosen = new ExerciseModels();
            ExerciseJsonModel exerciseJsonModel = new ExerciseJsonModel();

            var client = new RestClient("https://wger.de/api/v2/exercise/" + id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "031c9e8b-9b4d-a960-8a74-b93b086e2b61");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            var json = JsonConvert.DeserializeObject<ExerciseJsonModel>(response.Content);
            exerciseJsonModel = json;

            choosen.ExerciseName = exerciseJsonModel.Name;
            choosen.Description = exerciseJsonModel.Description;
            choosen.UserId = user.Id;
            choosen.DateAdded = DateTime.Today;
            List<string> muscles = new List<string>();

            foreach(var muscle in exerciseJsonModel.Muscles)
            {
                muscles.Add(muscle.ToString());
            }
            choosen.Muscels = muscles;

            _context.ExerciseHistory.Add(choosen);
            _context.SaveChanges();

            return RedirectToAction("Index", "Exercise");
        }

        public ActionResult AddedExercise()
        {
            return View();
        }
    }
}