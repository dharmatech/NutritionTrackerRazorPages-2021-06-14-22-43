using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class ComplexFoodComponent
    {
        public int         Id            { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; } // navigation

        public int         ComplexFoodId { get; set; }
        public ComplexFood ComplexFood   { get; set; } // navigation
        public int         SimpleFoodId  { get; set; }
        public SimpleFood  SimpleFood    { get; set; } // navigation
        public decimal     Amount        { get; set; }

        [ValidateNever] public decimal Calories           => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Calories;
        [ValidateNever] public decimal Fat                => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Fat;
        [ValidateNever] public decimal MonounsaturatedFat => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.MonounsaturatedFat;
        [ValidateNever] public decimal PolyunsaturatedFat => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.PolyunsaturatedFat;
        [ValidateNever] public decimal Omega3             => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Omega3;
        [ValidateNever] public decimal Omega6             => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Omega6;
        [ValidateNever] public decimal SaturatedFat       => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.SaturatedFat;
        [ValidateNever] public decimal TransFat           => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.TransFat;
        [ValidateNever] public decimal Cholesterol        => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Cholesterol;
        [ValidateNever] public decimal Carbohydrates      => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Carbohydrates;
        [ValidateNever] public decimal Fiber              => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Fiber;
        [ValidateNever] public decimal SolubleFiber       => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.SolubleFiber;
        [ValidateNever] public decimal InsolubleFiber     => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.InsolubleFiber;
        [ValidateNever] public decimal Starch             => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Starch;
        [ValidateNever] public decimal Sugars             => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Sugars;
        [ValidateNever] public decimal AddedSugars        => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.AddedSugars;
        [ValidateNever] public decimal Protein            => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Protein;
        [ValidateNever] public decimal VitaminB1          => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminB1;
        [ValidateNever] public decimal VitaminB2          => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminB2;
        [ValidateNever] public decimal VitaminB3          => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminB3;
        [ValidateNever] public decimal VitaminB5          => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminB5;
        [ValidateNever] public decimal VitaminB6          => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminB6;
        [ValidateNever] public decimal VitaminB12         => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminB12;
        [ValidateNever] public decimal Folate             => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Folate;
        [ValidateNever] public decimal VitaminA           => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminA;
        [ValidateNever] public decimal VitaminC           => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminC;
        [ValidateNever] public decimal VitaminD           => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminD;
        [ValidateNever] public decimal VitaminE           => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminE;
        [ValidateNever] public decimal VitaminK           => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.VitaminK;
        [ValidateNever] public decimal Calcium            => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Calcium;
        [ValidateNever] public decimal Copper             => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Copper;
        [ValidateNever] public decimal Iron               => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Iron;
        [ValidateNever] public decimal Magnesium          => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Magnesium;
        [ValidateNever] public decimal Manganese          => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Manganese;
        [ValidateNever] public decimal Phosphorus         => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Phosphorus;
        [ValidateNever] public decimal Potassium          => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Potassium;
        [ValidateNever] public decimal Selenium           => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Selenium;
        [ValidateNever] public decimal Sodium             => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Sodium;
        [ValidateNever] public decimal Zinc               => SimpleFood == null ? 0 : Amount / SimpleFood.ServingSize * SimpleFood.Zinc;
        
    }
}
