using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Authorization;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.ComplexFoods
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private IAuthorizationService AuthorizationService { get; }

        public EditModel(ApplicationDbContext context, IAuthorizationService authorizationService)
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
                .Include(c => c.User).FirstOrDefaultAsync(m => m.Id == id);

            if (ComplexFood == null) return NotFound();

            {
                var authorizationResult = await AuthorizationService.AuthorizeAsync(User, ComplexFood, ItemOperations.Delete);

                if (authorizationResult.Succeeded == false) return Forbid();
            }

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            
            _context.Attach(ComplexFood).State = EntityState.Modified;

            {
                var authorizationResult = await AuthorizationService.AuthorizeAsync(User, ComplexFood, ItemOperations.Delete);

                if (authorizationResult.Succeeded == false) return Forbid();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplexFoodExists(ComplexFood.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ComplexFoodExists(int id)
        {
            return _context.ComplexFood.Any(e => e.Id == id);
        }
    }
}
