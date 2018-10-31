using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeOrdersSeeder : BaseSeeder<Order>
    {
        protected override IEnumerable<Order> Seeds
            => new[]
            {
                new Order(1, 1, 100, 100, 1),
                new Order(2, 1, 100, 100, 2) 
            };
    }
}