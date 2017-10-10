using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.ViewModels
{
    public class ChartViewModel
    {
        public List<double> Calories { get; set; }

        public List<string> DateAdded { get; set; }
    }
}