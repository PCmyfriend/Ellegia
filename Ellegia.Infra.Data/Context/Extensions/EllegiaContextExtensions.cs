using System;
using System.Collections.Generic;
using System.Linq;
using Ellegia.Domain.Models;
using Ellegia.Infra.CrossCutting.Identity.Constants;
using Ellegia.Infra.Data.Context.Seeding;
using Ellegia.Infra.Data.Context.Seeding.Seeders.Fake;
using Ellegia.Infra.Data.Utilities.ConfigurationReader.Contracts;
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
            
        public static void EnsureSeeded(this EllegiaContext context, 
            IServiceProvider serviceProvider, IConfigurationReader configurationReader)
        {
            var users = configurationReader.Read();

            var userManager =
                serviceProvider.GetRequiredService<UserManager<EllegiaUser>>();
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<EllegiaRole>>();

            foreach (var user in users)
            {
                if (userManager.FindByNameAsync(user.Name).Result != null)
                    continue;

                if (roleManager.FindByNameAsync(user.Role).Result == null)
                {
                    var createRoleResult = roleManager.CreateAsync(new EllegiaRole {Name = user.Role}).Result;
                }

                var warehouse = context.Warehouses.First();                 
                var ellegiaUser = new EllegiaUser(user.Name, user.Email, user.FullName, warehouse.Id);

                var createUserResult = userManager
                    .CreateAsync(ellegiaUser, user.Password).Result;
                if (createUserResult.Succeeded)
                {
                    var addUserToRoleResult = userManager.AddToRoleAsync(ellegiaUser, user.Role).Result;
                }
            }

            var ellegiaUsers = userManager.GetUsersInRoleAsync(Roles.SupervisorNormalizedName).Result;

            if (!context.Shifts.Any())
            {
                context.Shifts.Add(new Shift("Смена #1", ellegiaUsers.First().Id));
                context.SaveChanges();
            }
        }
    }
}