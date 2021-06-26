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
        public static readonly string EditOperationName   = "Edit";
    }

    public static class ItemOperations
    {
        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement() { Name = Constants.DeleteOperationName };
        public static OperationAuthorizationRequirement Edit   = new OperationAuthorizationRequirement() { Name = Constants.EditOperationName };
    }
}
