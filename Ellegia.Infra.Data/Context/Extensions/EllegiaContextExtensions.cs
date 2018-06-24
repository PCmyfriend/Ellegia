using System;
using System.Collections.Generic;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context.Seeding;
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
            IEnumerable<(string userName, string userRole, string email, string password)> ellegiaUsers)
        {
            var userManager =
                serviceProvider.GetRequiredService<UserManager<EllegiaUser>>();
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<EllegiaRole>>();

            foreach (var (userName, userRole, email, password) in ellegiaUsers)
            {
                if (await userManager.FindByNameAsync(userName) != null) continue;

                if (await roleManager.FindByNameAsync(userRole) == null)
                    await roleManager.CreateAsync(new EllegiaRole { Name = userRole });

                var user = new EllegiaUser
                {
                    UserName = userName,
                    Email = email
                };

                var result = await userManager
                    .CreateAsync(user, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, userRole);
            }          
        }
    }
}