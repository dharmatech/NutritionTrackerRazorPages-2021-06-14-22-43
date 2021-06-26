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

namespace NutritionTrackerRazorPages.Pages.ComplexFoods
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
        public ComplexFood ComplexFood { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();
            
            ComplexFood = await _context.ComplexFood
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ComplexFood == null) return NotFound();

            {
                var authorizationResult = await AuthorizationService.AuthorizeAsync(User, ComplexFood, ItemOperations.Delete);

                if (authorizationResult.Succeeded == false) return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();
            
            ComplexFood = await _context.ComplexFood.FindAsync(id);

            if (ComplexFood != null)
            {
                {
                    var authorizationResult = await AuthorizationService.AuthorizeAsync(User, ComplexFood, ItemOperations.Delete);

                    if (authorizationResult.Succeeded == false) return Forbid();
                }

                _context.ComplexFood.Remove(ComplexFood);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
