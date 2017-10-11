using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.ViewModels
{
    public class ExerciseHistroyViewModel
    {
        public IEnumerable<ExerciseModels> ExerciseHistory { get; set; }
    }
}