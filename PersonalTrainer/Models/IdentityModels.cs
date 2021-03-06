﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;

namespace PersonalTrainer.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Weight { get; set; }
        public string HeightFeet { get; set; }
        public string HeightInches { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Goal { get; set; }
        public string GoalWeight { get; set; }
        public string ActivityLevel { get; set; }
        public string BMI { get; set; }
        public string BmiIndicator { get; set; }
        public List<string> ActivityList { get; set; }
        public List<string> GenderList { get; set; }
        public DateTime? LastUpdate { get; set; }
        public IEnumerable<UserImgPathModel> UserImg { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ProfileUpdatesModels> ProfileHistory { get; set; }
        public DbSet<UserImgPathModel> ImgPaths { get; set; }

        public DbSet<FoodInputModels> FoodInput { get; set; }

        public DbSet<ExerciseModels> ExerciseHistory { get; set; }
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}