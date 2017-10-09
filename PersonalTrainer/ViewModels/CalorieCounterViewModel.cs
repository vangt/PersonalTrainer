using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.ViewModels
{
    public class CalorieCounterViewModel
    {
        public ApplicationUser User { get; set; }

        public IEnumerable<FoodInputModels> Foodlist { get; set; }

        public SearchCaloriesViewModel SearchCalories { get; set; }
    }
}