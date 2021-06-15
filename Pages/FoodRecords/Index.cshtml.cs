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
    public class IndexModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.ApplicationDbContext _context;

        public IndexModel(NutritionTrackerRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FoodRecord> FoodRecord { get;set; }

        public async Task OnGetAsync()
        {
            FoodRecord = await _context.FoodRecord
                .Include(f => f.Food).ToListAsync();
        }
    }
}
