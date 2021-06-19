using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class FoodRecord
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; } // navigation

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; } // navigation

        public decimal Amount { get; set; }

        [ValidateNever] public decimal Calories           => Amount / Food.ServingSize * Food.Calories;
        [ValidateNever] public decimal Fat                => Amount / Food.ServingSize * Food.Fat;
        [ValidateNever] public decimal MonounsaturatedFat => Amount / Food.ServingSize * Food.MonounsaturatedFat;
        [ValidateNever] public decimal PolyunsaturatedFat => Amount / Food.ServingSize * Food.PolyunsaturatedFat;
        [ValidateNever] public decimal Omega3             => Amount / Food.ServingSize * Food.Omega3;
        [ValidateNever] public decimal Omega6             => Amount / Food.ServingSize * Food.Omega6;
        [ValidateNever] public decimal SaturatedFat       => Amount / Food.ServingSize * Food.SaturatedFat;
        [ValidateNever] public decimal TransFat           => Amount / Food.ServingSize * Food.TransFat;
        [ValidateNever] public decimal Cholesterol        => Amount / Food.ServingSize * Food.Cholesterol;
        [ValidateNever] public decimal Carbohydrates      => Amount / Food.ServingSize * Food.Carbohydrates;
        [ValidateNever] public decimal Fiber              => Amount / Food.ServingSize * Food.Fiber;
        [ValidateNever] public decimal SolubleFiber       => Amount / Food.ServingSize * Food.SolubleFiber;
        [ValidateNever] public decimal InsolubleFiber     => Amount / Food.ServingSize * Food.InsolubleFiber;
        [ValidateNever] public decimal Starch             => Amount / Food.ServingSize * Food.Starch;
        [ValidateNever] public decimal Sugars             => Amount / Food.ServingSize * Food.Sugars;
        [ValidateNever] public decimal AddedSugars        => Amount / Food.ServingSize * Food.AddedSugars;
        [ValidateNever] public decimal Protein            => Amount / Food.ServingSize * Food.Protein;
        [ValidateNever] public decimal VitaminB1          => Amount / Food.ServingSize * Food.VitaminB1;
        [ValidateNever] public decimal VitaminB2          => Amount / Food.ServingSize * Food.VitaminB2;
        [ValidateNever] public decimal VitaminB3          => Amount / Food.ServingSize * Food.VitaminB3;
        [ValidateNever] public decimal VitaminB5          => Amount / Food.ServingSize * Food.VitaminB5;
        [ValidateNever] public decimal VitaminB6          => Amount / Food.ServingSize * Food.VitaminB6;
        [ValidateNever] public decimal VitaminB12         => Amount / Food.ServingSize * Food.VitaminB12;
        [ValidateNever] public decimal Folate             => Amount / Food.ServingSize * Food.Folate;
        [ValidateNever] public decimal VitaminA           => Amount / Food.ServingSize * Food.VitaminA;
        [ValidateNever] public decimal VitaminC           => Amount / Food.ServingSize * Food.VitaminC;
        [ValidateNever] public decimal VitaminD           => Amount / Food.ServingSize * Food.VitaminD;
        [ValidateNever] public decimal VitaminE           => Amount / Food.ServingSize * Food.VitaminE;
        [ValidateNever] public decimal VitaminK           => Amount / Food.ServingSize * Food.VitaminK;
        [ValidateNever] public decimal Calcium            => Amount / Food.ServingSize * Food.Calcium;
        [ValidateNever] public decimal Copper             => Amount / Food.ServingSize * Food.Copper;
        [ValidateNever] public decimal Iron               => Amount / Food.ServingSize * Food.Iron;
        [ValidateNever] public decimal Magnesium          => Amount / Food.ServingSize * Food.Magnesium;
        [ValidateNever] public decimal Manganese          => Amount / Food.ServingSize * Food.Manganese;
        [ValidateNever] public decimal Phosphorus         => Amount / Food.ServingSize * Food.Phosphorus;
        [ValidateNever] public decimal Potassium          => Amount / Food.ServingSize * Food.Potassium;
        [ValidateNever] public decimal Selenium           => Amount / Food.ServingSize * Food.Selenium;
        [ValidateNever] public decimal Sodium             => Amount / Food.ServingSize * Food.Sodium;
        [ValidateNever] public decimal Zinc               => Amount / Food.ServingSize * Food.Zinc;        
    }
}
