using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.Models
{
    public class ProfileUpdatesModels
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Age { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public string ActivityLevel { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfLog { get; set; }
    }
}