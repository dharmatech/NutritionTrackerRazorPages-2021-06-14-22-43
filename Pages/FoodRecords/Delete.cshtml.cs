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

namespace NutritionTrackerRazorPages.Pages.FoodRecords
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
        public FoodRecord FoodRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodRecord = await _context.FoodRecord
                .Include(f => f.Food)
                .Include(f => f.User).FirstOrDefaultAsync(m => m.Id == id);

            if (FoodRecord == null)
            {
                return NotFound();
            }

            {
                var authorizationResult = await AuthorizationService.AuthorizeAsync(User, FoodRecord, ItemOperations.Delete);

                if (authorizationResult.Succeeded == false) return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodRecord = await _context.FoodRecord.FindAsync(id);

            if (FoodRecord != null)
            {
                {
                    var authorizationResult = await AuthorizationService.AuthorizeAsync(User, FoodRecord, ItemOperations.Delete);

                    if (authorizationResult.Succeeded == false) return Forbid();
                }

                _context.FoodRecord.Remove(FoodRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
