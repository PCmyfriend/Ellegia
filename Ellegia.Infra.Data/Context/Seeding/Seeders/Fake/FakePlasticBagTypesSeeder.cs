using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakePlasticBagTypesSeeder : BaseSeeder<PlasticBagType>
    {
        protected override IEnumerable<PlasticBagType> Seeds 
            => new[]
            {
                new PlasticBagType("Майка"),
                new PlasticBagType("Вырезная ручка"), 
            };
    }
}