using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeCustomersSeeder : BaseSeeder<Customer>
    {
        protected override IEnumerable<Customer> Seeds 
            => new[]
            {
                new Customer("Григорий Держанский"),
                new Customer("Евгений Кузнецов")
            };
    }
}