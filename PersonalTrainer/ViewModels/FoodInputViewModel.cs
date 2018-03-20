using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTrainer.ViewModels
{
    public class FoodInputViewModel
    {
        [Display(Name = "Name of Food")]
        public string FoodName { get; set; }

        [Display(Name = "Fat")]
        public string Fat { get; set; }

        [Display(Name = "Protien")]
        public string Protien { get; set; }

        [Display(Name = "Carb")]
        public string Carb { get; set; }

        [Display(Name = "Calories")]
        public string Calories { get; set; }
    }
}