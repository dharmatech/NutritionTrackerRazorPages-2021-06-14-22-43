using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class SimpleFood : Food
    {
        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; } // navigation property
                
        public override decimal Calories           { get; set; }
        public override decimal Fat                { get; set; }
        public override decimal MonounsaturatedFat { get; set; }
        public override decimal PolyunsaturatedFat { get; set; }
        public override decimal Omega3             { get; set; }
        public override decimal Omega6             { get; set; }
        public override decimal SaturatedFat       { get; set; }
        public override decimal TransFat           { get; set; }
        public override decimal Cholesterol        { get; set; }
        public override decimal Carbohydrates      { get; set; }
        public override decimal Fiber              { get; set; }
        public override decimal SolubleFiber       { get; set; }
        public override decimal InsolubleFiber     { get; set; }
        public override decimal Starch             { get; set; }
        public override decimal Sugars             { get; set; }
        public override decimal AddedSugars        { get; set; }
        public override decimal Protein            { get; set; }
        public override decimal VitaminB1          { get; set; }
        public override decimal VitaminB2          { get; set; }
        public override decimal VitaminB3          { get; set; }
        public override decimal VitaminB5          { get; set; }
        public override decimal VitaminB6          { get; set; }
        public override decimal VitaminB12         { get; set; }
        public override decimal Folate             { get; set; }
        public override decimal VitaminA           { get; set; }
        public override decimal VitaminC           { get; set; }
        public override decimal VitaminD           { get; set; }
        public override decimal VitaminE           { get; set; }
        public override decimal VitaminK           { get; set; }
        public override decimal Calcium            { get; set; }
        public override decimal Copper             { get; set; }
        public override decimal Iron               { get; set; }
        public override decimal Magnesium          { get; set; }
        public override decimal Manganese          { get; set; }
        public override decimal Phosphorus         { get; set; }
        public override decimal Potassium          { get; set; }
        public override decimal Selenium           { get; set; }
        public override decimal Sodium             { get; set; }
        public override decimal Zinc               { get; set; }        
    }
}
