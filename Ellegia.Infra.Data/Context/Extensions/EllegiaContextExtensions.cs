using System.Collections.Generic;
using Ellegia.Infra.Data.Context.Seeding;

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
    }
}