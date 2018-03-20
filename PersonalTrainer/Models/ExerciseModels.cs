using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.Models
{
    public class ExerciseModels
    {
        public int Id { get; set; } 

        public int? TableID { get; set; }

        public DateTime? DateAdded { get; set; }

        public string UserId { get; set; }

        public string ExerciseName { get; set; }

        public string ExerciseId { get; set; }

        public string Description { get; set; }

        public List<string> Muscles { get; set; }
    }
}