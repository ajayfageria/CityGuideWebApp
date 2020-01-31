using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class ApplicationHandler:AuthorizationHandler<ApplicationIdRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApplicationIdRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "ApplicationID"))
            {
                var Appid = new Guid(context.User.FindFirst(c => c.Type=="ApplicationID").Value);
                if (Appid.Equals(requirement.ApplicationId)) {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask;
        }
    }
}
