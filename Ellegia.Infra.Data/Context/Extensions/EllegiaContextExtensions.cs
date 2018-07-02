using System;
using System.Collections.Generic;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context.Seeding;
using Ellegia.Infra.Data.Utilities.ConfigurationReader.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Ellegia.Infra.Data.Context.Extensions
{
    public static class EllegiaContextExtensions
    {
        public static void EnsureSeeded(this EllegiaContext context, IEnumerable<ISeeder> seeders)
        {
            foreach (var seeder in seeders)
            {
                seeder.Seed(context);
            }
        }

        public static async void EnsureSeeded(this EllegiaContext context, IServiceProvider serviceProvider, 
            IEnumerable<UserInfo> usersInfo)
        {   
            var userManager =
                serviceProvider.GetRequiredService<UserManager<EllegiaUser>>();
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<EllegiaRole>>();
                
            foreach (var userInfo in usersInfo)     
            {
                if (await userManager.FindByNameAsync(userInfo.Name) != null) continue;

                if (await roleManager.FindByNameAsync(userInfo.Role) == null)
                    await roleManager.CreateAsync(new EllegiaRole { Name = userInfo.Role });

                var user = new EllegiaUser
                {
                    UserName = userInfo.Name,
                    Email = userInfo.Email
                };

                var result = await userManager
                    .CreateAsync(user, userInfo.Email);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, userInfo.Role);
            }          
        }
    }
}