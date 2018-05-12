using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeColorsSeeder : BaseSeeder<Color>
    {
        protected override IEnumerable<Color> Seeds =>
            new[]
            {
                new Color(0, "Зеленый"),
                new Color(0, "Белый"),
                new Color(0, "Бесцветный")
            };
    }
}