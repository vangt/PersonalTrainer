using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTrainer.ViewModels
{
    public class SearchCaloriesViewModel
    {
        [Display(Name = "Food Name (Please be as specific as you can)")]
        public FoodInputModels FoodInputModel { get; set; }

        public string SearchWordInput { get; set; }

        public string SearchOptionInput { get; set; }

        public string Ndbno { get; set; }

        public string ItemName { get; set; }

        public string Calories { get; set; }

        public string Protiens { get; set; }

        public string Carbs { get; set; }

        public string Fats { get; set; }

        public Dictionary<string, string> IdName { get; set; }

        public FoodAPI FoodApi { get; set;}
    }
}