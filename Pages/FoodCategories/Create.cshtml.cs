using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.FoodCategories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            
            return Page();
        }

        [BindProperty]
        public FoodCategory FoodCategory { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            
            FoodCategory.UserId = _userManager.GetUserId(User);

            _context.FoodCategory.Add(FoodCategory);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
