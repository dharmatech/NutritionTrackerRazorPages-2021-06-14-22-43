using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public interface IUserOwned
    {
        public string UserId { get; set; }
                
        public IdentityUser User { get; set; } // navigation
    }
}
