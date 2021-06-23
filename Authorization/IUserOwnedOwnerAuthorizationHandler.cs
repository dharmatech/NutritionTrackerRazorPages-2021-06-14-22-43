﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using NutritionTrackerRazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Authorization
{
    public class IUserOwnedOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, IUserOwned>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public IUserOwnedOwnerAuthorizationHandler(UserManager<IdentityUser> userManager) => _userManager = userManager;

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            OperationAuthorizationRequirement requirement, 
            IUserOwned resource)
        {
            if (context.User == null || resource == null) return Task.CompletedTask;

            if (requirement.Name != Constants.DeleteOperationName) return Task.CompletedTask;

            if (resource.UserId == _userManager.GetUserId(context.User)) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
