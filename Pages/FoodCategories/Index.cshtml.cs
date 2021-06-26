using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.FoodCategories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private IAuthorizationService AuthorizationService { get; }

        public IndexModel(ApplicationDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            AuthorizationService = authorizationService;
        }

        public IList<FoodCategory> FoodCategory { get;set; }

        public async Task OnGetAsync()
        {
            FoodCategory = await _context.FoodCategory
                .Include(foodCategory => foodCategory.User)
                .Include(f => f.User).ToListAsync();
        }
    }
}
