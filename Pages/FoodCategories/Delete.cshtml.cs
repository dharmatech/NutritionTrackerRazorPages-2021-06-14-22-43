using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Authorization;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.FoodCategories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private IAuthorizationService AuthorizationService { get; }
        private UserManager<IdentityUser> UserManager { get; }

        public DeleteModel(
            ApplicationDbContext context, 
            IAuthorizationService authorizationService, 
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            AuthorizationService = authorizationService;
            UserManager = userManager;
        }

        [BindProperty]
        public FoodCategory FoodCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();
          
            FoodCategory = await _context.FoodCategory
                .Include(f => f.User).FirstOrDefaultAsync(m => m.Id == id);

            if (FoodCategory == null) return NotFound();

            {
                var is_authorized = await AuthorizationService.AuthorizeAsync(User, FoodCategory, ItemOperations.Delete);

                if (is_authorized.Succeeded == false) return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();
            
            FoodCategory = await _context.FoodCategory.FindAsync(id);

            if (FoodCategory == null) return NotFound();

            var is_authorized = await AuthorizationService.AuthorizeAsync(User, FoodCategory, ItemOperations.Delete);

            if (is_authorized.Succeeded == false) return Forbid();

            _context.FoodCategory.Remove(FoodCategory);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
