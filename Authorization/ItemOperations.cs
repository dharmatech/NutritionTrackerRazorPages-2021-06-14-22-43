using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Authorization
{
    public class Constants
    {
        public static readonly string DeleteOperationName = "Delete";
    }

    public static class ItemOperations
    {
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement()
            {
                Name = Constants.DeleteOperationName
            };
    }
}
