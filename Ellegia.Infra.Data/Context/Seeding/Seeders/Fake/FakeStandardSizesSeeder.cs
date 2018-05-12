using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeStandardSizesSeeder : BaseSeeder<StandardSize>
    {
        protected override IEnumerable<StandardSize> Seeds
            => new[]
            {
                new StandardSize(1, 10, 10, 10, 1000),
                new StandardSize(1, 3, 60, null, 3000),
                new StandardSize(2, 10, 10, 10, 1000),
                new StandardSize(2, 3, 60, null, 3000)
            };
    }
}