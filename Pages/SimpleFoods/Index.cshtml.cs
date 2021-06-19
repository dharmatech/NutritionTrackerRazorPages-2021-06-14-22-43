using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.SimpleFoods
{
    public class IndexModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.ApplicationDbContext _context;

        public IndexModel(NutritionTrackerRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SimpleFood> SimpleFood { get;set; }

        public async Task OnGetAsync()
        {
            SimpleFood = await _context.SimpleFood
                .Include(simpleFood => simpleFood.User)
                .Include(s => s.FoodCategory)
                .Include(s => s.User).ToListAsync();
        }
    }
}
