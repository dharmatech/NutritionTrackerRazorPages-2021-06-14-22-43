using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.FoodRecords
{
    public class IndexGroupedModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexGroupedModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FoodRecord> FoodRecord { get; set; }

        public async Task OnGetAsync()
        {
            FoodRecord = await _context.FoodRecord
                .OrderBy(foodRecord => foodRecord.Date)
                .ThenBy(foodRecord => foodRecord.Time)
                .Include(foodRecord => foodRecord.Food)
                .ThenInclude(food => (food as ComplexFood).ComplexFoodComponents)
                .Include(foodRecord => foodRecord.User)
                //.ThenInclude(complexFoodComponent => complexFoodComponent.SimpleFood)
                .ToListAsync();
        }
    }
}
