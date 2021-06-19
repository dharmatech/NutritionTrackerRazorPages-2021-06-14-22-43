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
    public class DetailsModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.ApplicationDbContext _context;

        public DetailsModel(NutritionTrackerRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public FoodRecord FoodRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodRecord = await _context.FoodRecord
                .Include(f => f.Food)
                .Include(f => f.User).FirstOrDefaultAsync(m => m.Id == id);

            if (FoodRecord == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
