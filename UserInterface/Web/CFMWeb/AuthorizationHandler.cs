using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CFMCommon;

namespace CFMWeb
{
    public class UserFuntionAuthorizationRequirement : IAuthorizationRequirement
    {

        public string RoleName { get; private set; }
        public UserFuntionAuthorizationRequirement()
        {

        }
        public UserFuntionAuthorizationRequirement(string functionName)
        {
            RoleName = functionName;
        }
    }
    public class AuthorizationHandler : AuthorizationHandler<UserFuntionAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserFuntionAuthorizationRequirement requirement)
        {
            var httpContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext).HttpContext;
            ClaimsPrincipal principal = httpContext.User;

            if (!context.User.HasClaim(c => c.Type == UserClaims.Roles.ToString()))
            {

                context.Fail();
                return Task.CompletedTask;
            }

            var userRoles = context.User.FindFirst(c => c.Type == UserClaims.Roles.ToString()).Value;
            if (string.IsNullOrEmpty(requirement.RoleName))
            {
                context.Succeed(requirement);
            }
            else
            {
                if (!string.IsNullOrEmpty(userRoles))
                {
                    foreach (string userRole in userRoles.Split(","))
                    {
                        if (userRole.ToLower() == SystemRoleTypeEnum.CFMAdmin.ToString().ToLower())
                        {
                            context.Succeed(requirement);
                            return Task.CompletedTask;
                        }

                        string[] requiredRoles = requirement.RoleName.ToLower().Split(',');
                        foreach (string rf in requiredRoles)
                        {
                            if (userRole.ToLower() == rf)
                            {
                                context.Succeed(requirement);
                                return Task.CompletedTask;
                            }
                        }

                    }
                }
                context.Fail();

            }


            return Task.CompletedTask;
        }
    }
}
