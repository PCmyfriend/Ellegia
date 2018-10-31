using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeShiftsSeeder : BaseSeeder<Shift>
    {
        protected override IEnumerable<Shift> Seeds
            => new[]
            {
                new Shift(0, "Смена №1") 
            };
    }
}
