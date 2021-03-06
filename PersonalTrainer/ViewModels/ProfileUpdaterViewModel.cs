﻿using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTrainer.ViewModels
{
    public class ProfileUpdaterViewModel
    {
        public ApplicationUser User { get; set; }

        [Required]
        [MaxLength(3)]
        [MinLength(2)]
        [RegularExpression("[0-9]*$", ErrorMessage = "AGE must be numeric")]
        [Display(Name = "Age")]
        public string Age { get; set; }

        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        [RegularExpression("[0-9]*$", ErrorMessage = "Height must be numeric")]
        [Display(Name = "Height (Feet)")]
        public string HeightFeet { get; set; }

        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        [RegularExpression("[0-9]*$", ErrorMessage = "Height must be numeric")]
        [Display(Name = "Height (Inches)")]
        public string HeightInches { get; set; }

        [Required]
        [MaxLength(3)]
        [MinLength(2)]
        [RegularExpression("[0-9]*$", ErrorMessage = "Weight must be numeric")]
        [Display(Name = "Weight (POUNDS)")]
        public string Weight { get; set; }

        [Required]
        [MaxLength(3)]
        [MinLength(2)]
        [RegularExpression("[0-9]*$", ErrorMessage = "Goal must be numeric")]
        [Display(Name = "Goal Weight (POUNDS)")]
        public string GoalWeight { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Your Activity Level")]
        public string ActivityLevel { get; set; }
    }
}