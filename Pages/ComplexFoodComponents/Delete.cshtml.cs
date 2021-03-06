using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.ComplexFoodComponents
{
    public class DeleteModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.ApplicationDbContext _context;

        public DeleteModel(NutritionTrackerRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ComplexFoodComponent ComplexFoodComponent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ComplexFoodComponent = await _context.ComplexFoodComponent
                .Include(c => c.ComplexFood)
                .Include(c => c.SimpleFood)
                .Include(c => c.User).FirstOrDefaultAsync(m => m.Id == id);

            if (ComplexFoodComponent == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ComplexFoodComponent = await _context.ComplexFoodComponent.FindAsync(id);

            if (ComplexFoodComponent != null)
            {
                _context.ComplexFoodComponent.Remove(ComplexFoodComponent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
