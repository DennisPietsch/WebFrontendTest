using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Authorization
{
    public class ContactAdministratorsAuthorizationHandler
                    :AuthorizationHandler<OperationAuthorizationRequirement, Kunde>
    {
       protected override Task HandleRequirementAsync(
           AuthorizationHandlerContext context,
           OperationAuthorizationRequirement requirement,
           Kunde resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(Constants.ContactAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
       } 
    }
}
