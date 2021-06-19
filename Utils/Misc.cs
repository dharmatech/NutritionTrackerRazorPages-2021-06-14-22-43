using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Utils
{
    public static class Misc
    {
        public static decimal RoundData(decimal n) => n == 0 ? 0 : n >= 10 ? Math.Round(n) : Math.Round(n, 2);
    }
}
