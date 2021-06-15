using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class ComplexFood : Food
    {
        public List<ComplexFoodComponent> ComplexFoodComponents { get; set; } // navigation
        
        [ValidateNever] public override decimal Calories           { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Calories); set { } }
        [ValidateNever] public override decimal Fat                { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Fat); set { } }
        [ValidateNever] public override decimal MonounsaturatedFat { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.MonounsaturatedFat); set { } }
        [ValidateNever] public override decimal PolyunsaturatedFat { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.PolyunsaturatedFat); set { } }
        [ValidateNever] public override decimal Omega3             { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Omega3); set { } }
        [ValidateNever] public override decimal Omega6             { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Omega6); set { } }
        [ValidateNever] public override decimal SaturatedFat       { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.SaturatedFat); set { } }
        [ValidateNever] public override decimal TransFat           { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.TransFat); set { } }
        [ValidateNever] public override decimal Cholesterol        { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Cholesterol); set { } }
        [ValidateNever] public override decimal Carbohydrates      { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Carbohydrates); set { } }
        [ValidateNever] public override decimal Fiber              { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Fiber); set { } }
        [ValidateNever] public override decimal SolubleFiber       { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.SolubleFiber); set { } }
        [ValidateNever] public override decimal InsolubleFiber     { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.InsolubleFiber); set { } }
        [ValidateNever] public override decimal Starch             { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Starch); set { } }
        [ValidateNever] public override decimal Sugars             { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Sugars); set { } }
        [ValidateNever] public override decimal AddedSugars        { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.AddedSugars); set { } }
        [ValidateNever] public override decimal Protein            { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Protein); set { } }
        [ValidateNever] public override decimal VitaminB1          { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminB1); set { } }
        [ValidateNever] public override decimal VitaminB2          { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminB2); set { } }
        [ValidateNever] public override decimal VitaminB3          { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminB3); set { } }
        [ValidateNever] public override decimal VitaminB5          { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminB5); set { } }
        [ValidateNever] public override decimal VitaminB6          { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminB6); set { } }
        [ValidateNever] public override decimal VitaminB12         { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminB12); set { } }
        [ValidateNever] public override decimal Folate             { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Folate); set { } }
        [ValidateNever] public override decimal VitaminA           { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminA); set { } }
        [ValidateNever] public override decimal VitaminC           { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminC); set { } }
        [ValidateNever] public override decimal VitaminD           { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminD); set { } }
        [ValidateNever] public override decimal VitaminE           { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminE); set { } }
        [ValidateNever] public override decimal VitaminK           { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.VitaminK); set { } }
        [ValidateNever] public override decimal Calcium            { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Calcium); set { } }
        [ValidateNever] public override decimal Copper             { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Copper); set { } }
        [ValidateNever] public override decimal Iron               { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Iron); set { } }
        [ValidateNever] public override decimal Magnesium          { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Magnesium); set { } }
        [ValidateNever] public override decimal Manganese          { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Manganese); set { } }
        [ValidateNever] public override decimal Phosphorus         { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Phosphorus); set { } }
        [ValidateNever] public override decimal Potassium          { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Potassium); set { } }
        [ValidateNever] public override decimal Selenium           { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Selenium); set { } }
        [ValidateNever] public override decimal Sodium             { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Sodium); set { } }
        [ValidateNever] public override decimal Zinc               { get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Zinc); set { } }        
    }
}
