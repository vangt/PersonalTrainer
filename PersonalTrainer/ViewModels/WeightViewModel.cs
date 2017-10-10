using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.ViewModels
{
    public class WeightViewModel
    {
        public List<string> Weight { get; set; }

        public List<DateTime?> DateAdded { get; set; }
    }
}