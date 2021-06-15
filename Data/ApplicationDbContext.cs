using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NutritionTrackerRazorPages.Models.FoodCategory> FoodCategory { get; set; }
        public DbSet<NutritionTrackerRazorPages.Models.SimpleFood> SimpleFood { get; set; }
        public DbSet<NutritionTrackerRazorPages.Models.ComplexFood> ComplexFood { get; set; }
        public DbSet<NutritionTrackerRazorPages.Models.ComplexFoodComponent> ComplexFoodComponent { get; set; }
        public DbSet<NutritionTrackerRazorPages.Models.FoodRecord> FoodRecord { get; set; }
    }
}
