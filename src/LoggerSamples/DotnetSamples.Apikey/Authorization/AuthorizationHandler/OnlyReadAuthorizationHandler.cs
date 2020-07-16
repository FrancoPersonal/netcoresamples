using DotnetSamples.Apikey.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerAspNetCore.Authorization.AuthorizationHandler
{
    public class OnlyReadAuthorizationHandler : AuthorizationHandler<OnlyReadRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyReadRequirement requirement)
        {
            if (context.User.IsInRole(requirement.Rol))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
