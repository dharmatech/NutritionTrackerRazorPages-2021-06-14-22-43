using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.SimpleFoods
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext      _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<SimpleFood> SimpleFoods { get;set; }

        public async Task OnGetAsync()
        {
            var foods = _context.SimpleFood
                .Include(simpleFood => simpleFood.User)
                .Include(simpleFood => simpleFood.FoodCategory)
                .AsEnumerable();
                        
            var foods_user = foods
                .Where(simpleFood => simpleFood.User.UserName == _userManager.GetUserName(User))
                .OrderBy(simpleFood => simpleFood.Name);
                        
            var foods_admin = foods
                .Where(simpleFood => simpleFood.UserId == _userManager.FindByNameAsync("admin").Result.Id)
                .OrderBy(simpleFood => simpleFood.Name);

            var foods_others = foods.Except(foods_user).Except(foods_admin);

            SimpleFoods = foods_user.Concat(foods_admin)
                .Concat(foods_others)
                .ToList();
        }

    }
}
