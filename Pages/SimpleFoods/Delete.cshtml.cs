using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Authorization;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.SimpleFoods
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private IAuthorizationService AuthorizationService { get; }

        public DeleteModel(ApplicationDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            AuthorizationService = authorizationService;
        }

        [BindProperty]
        public SimpleFood SimpleFood { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            SimpleFood = await _context.SimpleFood
                .Include(s => s.FoodCategory)
                .Include(s => s.User).FirstOrDefaultAsync(m => m.Id == id);
                        
            if (SimpleFood == null) return NotFound();

            {
                var authorizationResult = await AuthorizationService.AuthorizeAsync(User, SimpleFood, ItemOperations.Delete);

                if (authorizationResult.Succeeded == false) return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();
            
            SimpleFood = await _context.SimpleFood.FindAsync(id);

            if (SimpleFood != null)
            {
                {
                    var authorizationResult = await AuthorizationService.AuthorizeAsync(User, SimpleFood, ItemOperations.Delete);

                    if (authorizationResult.Succeeded == false) return Forbid();
                }

                _context.SimpleFood.Remove(SimpleFood);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
