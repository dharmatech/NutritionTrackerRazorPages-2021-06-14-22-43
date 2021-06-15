using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public abstract class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; } // navigation

        public decimal ServingSize { get; set; }

        public abstract decimal Calories { get; set; }
        public abstract decimal Fat { get; set; }
        public abstract decimal MonounsaturatedFat { get; set; }
        public abstract decimal PolyunsaturatedFat { get; set; }
        public abstract decimal Omega3 { get; set; }
        public abstract decimal Omega6 { get; set; }
        public abstract decimal SaturatedFat { get; set; }
        public abstract decimal TransFat { get; set; }
        public abstract decimal Cholesterol { get; set; }
        public abstract decimal Sodium { get; set; }
        public abstract decimal Carbohydrates { get; set; }
        public abstract decimal Fiber { get; set; }
        public abstract decimal SolubleFiber { get; set; }
        public abstract decimal InsolubleFiber { get; set; }
        public abstract decimal Starch { get; set; }
        public abstract decimal Sugars { get; set; }
        public abstract decimal AddedSugars { get; set; }
        public abstract decimal Protein { get; set; }
        public abstract decimal VitaminB1 { get; set; }
        public abstract decimal VitaminB2 { get; set; }
        public abstract decimal VitaminB3 { get; set; }
        public abstract decimal VitaminB5 { get; set; }
        public abstract decimal VitaminB6 { get; set; }
        public abstract decimal VitaminB12 { get; set; }
        public abstract decimal Folate { get; set; }
        public abstract decimal VitaminA { get; set; }
        public abstract decimal VitaminC { get; set; }
        public abstract decimal VitaminD { get; set; }
        public abstract decimal VitaminE { get; set; }
        public abstract decimal VitaminK { get; set; }
        public abstract decimal Calcium { get; set; }
        public abstract decimal Copper { get; set; }
        public abstract decimal Iron { get; set; }
        public abstract decimal Magnesium { get; set; }
        public abstract decimal Manganese { get; set; }
        public abstract decimal Phosphorus { get; set; }
        public abstract decimal Potassium { get; set; }
        public abstract decimal Selenium { get; set; }
        public abstract decimal Zinc { get; set; }

        public string Discriminator { get; set; }
    }
}
