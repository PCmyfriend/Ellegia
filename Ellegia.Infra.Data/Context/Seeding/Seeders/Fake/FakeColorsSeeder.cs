using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeColorsSeeder : BaseSeeder<Color>
    {
        protected override IEnumerable<Color> Seeds =>
            new[]
            {
                new Color("Зеленый"),
                new Color("Белый"),
                new Color("Бесцветный")
            };
    }
}