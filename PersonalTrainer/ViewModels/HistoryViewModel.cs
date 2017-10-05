using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.ViewModels
{
    public class HistoryViewModel
    {
        public ApplicationUser User { get; set; }

        public ProfileUpdatesModels ProfileUpdateModel { get; set; }

        public IEnumerable<ProfileUpdatesModels> ProfileList { get; set; }
    }
}