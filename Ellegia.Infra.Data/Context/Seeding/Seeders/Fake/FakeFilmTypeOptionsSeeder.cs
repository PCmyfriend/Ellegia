using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeFilmTypeOptionsSeeder : BaseSeeder<FilmTypeOption>
    {
        protected override IEnumerable<FilmTypeOption> Seeds
            => new[]
            {
                new FilmTypeOption("Рукав"), 
                new FilmTypeOption("Полурукав") 
            };
    }
}