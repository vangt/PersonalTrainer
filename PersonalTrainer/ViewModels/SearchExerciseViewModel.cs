using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.ViewModels
{
    public class SearchExerciseViewModel
    {
        public ExerciseModels ExerciseModel { get; set; }

        public ExerciseAPI ExerciseAPIs { get; set; }

        public string SearchMuscle { get; set; }

        public string ExerciseName { get; set; }

        public string ExerciseId { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> Muscles { get; set; }

        public ApplicationUser User { get; set; }
    }
}