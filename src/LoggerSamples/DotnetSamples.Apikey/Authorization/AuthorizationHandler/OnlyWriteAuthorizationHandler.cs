using LoggerAspNetCore.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerAspNetCore.Authorization.AuthorizationHandler
{
    public class OnlyManagersAuthorizationHandler : AuthorizationHandler<OnlyWriteRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyWriteRequirement requirement)
        {
            if (context.User.IsInRole(requirement.Rol))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
