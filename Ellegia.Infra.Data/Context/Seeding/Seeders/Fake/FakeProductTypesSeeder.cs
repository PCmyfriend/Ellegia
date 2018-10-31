using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeProductTypesSeeder : BaseSeeder<ProductType>
    {
        protected override IEnumerable<ProductType> Seeds
            => new[]
            {
                new ProductType("Продукт будущего", 1, 1, 1, false, 1, 1, 1, 1, 1, 1),
                new ProductType("Продукт прошлого", 1, 3, 2, true, 2, 2, 2, 2, 2, 2)
            };
    }
}