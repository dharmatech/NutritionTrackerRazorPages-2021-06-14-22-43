using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.FoodRecords
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private UserManager<IdentityUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public SelectList SelectListFoods { get; set; }

        public SelectList SelectList { get; set; }

        //public IList<Food> Foods { get; set; }


        //public IActionResult OnGet()
        //{
        //    ViewData["FoodId"] = new SelectList(_context.Food, "Id", "Name");


        //    //ViewData["FoodId"] = new SelectList(_context.Food, "Id", "Name", null, "UserId");

        //    SelectListFoods = new SelectList(_context.Food, "Id", "Name");




        //    //ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");


        //    Foods = _context.Food.Include(food => food.User).ToList();

        //    ViewData["FoodId"] = new SelectList(Foods, "Id", "Name", null, "User.UserName");

        //    return Page();
        //}

        public IActionResult OnGet()
        {
            var Foods = _context.Food
                .Include(food => food.User)
                .OrderBy(food => food.Name)
                .ToList();

            //ViewData["FoodId"] = new SelectList(Foods, "Id", "Name", null, "User.UserName");

            SelectList = new SelectList(Foods, "Id", "Name", null, "User.UserName");

            return Page();
        }

        [BindProperty]
        public FoodRecord FoodRecord { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            
            FoodRecord.UserId = _userManager.GetUserId(User);
                        
            _context.FoodRecord.Add(FoodRecord);

            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexGrouped");
        }
    }
}
