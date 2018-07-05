using System.Security.Claims;
using Ellegia.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Ellegia.WebApi.Extensions
{               
    public static class UserManagerExtensions           
    {
        public static int GetUserIdAsInt(this UserManager<EllegiaUser> userManager, ClaimsPrincipal user)
        {                  
           int.TryParse(userManager.GetUserId(user), out var parseResult);
           return parseResult;
        }
    }
}
