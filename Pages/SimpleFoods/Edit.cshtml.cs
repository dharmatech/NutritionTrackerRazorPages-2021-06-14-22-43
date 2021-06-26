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

namespace NutritionTrackerRazorPages.Pages.SimpleFoods
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
        public SimpleFood SimpleFood { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();
            
            SimpleFood = await _context.SimpleFood
                .Include(s => s.FoodCategory)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (SimpleFood == null) return NotFound();

            {
                var is_authorized = await AuthorizationService.AuthorizeAsync(User, SimpleFood, ItemOperations.Edit);

                if (is_authorized.Succeeded == false) return Forbid();
            }

            ViewData["FoodCategoryId"] = new SelectList(_context.FoodCategory, "Id", "Id");
           
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SimpleFood).State = EntityState.Modified;

            {
                var is_authorized = await AuthorizationService.AuthorizeAsync(User, SimpleFood, ItemOperations.Edit);

                if (is_authorized.Succeeded == false) return Forbid();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimpleFoodExists(SimpleFood.Id))
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

        private bool SimpleFoodExists(int id)
        {
            return _context.SimpleFood.Any(e => e.Id == id);
        }
    }
}
