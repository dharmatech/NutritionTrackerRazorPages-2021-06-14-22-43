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

namespace NutritionTrackerRazorPages.Pages.FoodCategories
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
        public FoodCategory FoodCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();
            
            FoodCategory = await _context.FoodCategory
                .Include(f => f.User).FirstOrDefaultAsync(m => m.Id == id);

            {
                var is_authorized = await AuthorizationService.AuthorizeAsync(User, FoodCategory, ItemOperations.Edit);

                if (is_authorized.Succeeded == false) return Forbid();
            }

            if (FoodCategory == null) return NotFound();

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(FoodCategory).State = EntityState.Modified;

            {
                var is_authorized = await AuthorizationService.AuthorizeAsync(User, FoodCategory, ItemOperations.Edit);

                if (is_authorized.Succeeded == false) return Forbid();
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodCategoryExists(FoodCategory.Id))
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

        private bool FoodCategoryExists(int id)
        {
            return _context.FoodCategory.Any(e => e.Id == id);
        }
    }
}
