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
        public DbSet<FoodCategory>         FoodCategory         { get; set; }

        public DbSet<Food>                 Food                 { get; set; }
        public DbSet<FoodRecord>           FoodRecord           { get; set; }

        public DbSet<SimpleFood>           SimpleFood           { get; set; }

        public DbSet<ComplexFood>          ComplexFood          { get; set; }
        public DbSet<ComplexFoodComponent> ComplexFoodComponent { get; set; }
        
    }
}

