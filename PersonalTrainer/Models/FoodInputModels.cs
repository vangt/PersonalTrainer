using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.Models
{
    public class FoodInputModels
    {
        public int Id { get; set; }

        public string FoodId { get; set; }

        public string UserId { get; set; }

        public string FoodName { get; set; }

        public string Calories { get; set; }

        public string Protien { get; set; }

        public string Carb { get; set; }

        public string Fat { get; set; }

        public string Weight { get; set; }

        public string Measure { get; set; }

        public DateTime? DateAdded { get; set; }
    }
}