using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeMeasurementUnitsSeeder : BaseSeeder<MeasurementUnit>
    {
        protected override IEnumerable<MeasurementUnit> Seeds
            => new[]
            {
                new MeasurementUnit("кг.")
            };
    }
}