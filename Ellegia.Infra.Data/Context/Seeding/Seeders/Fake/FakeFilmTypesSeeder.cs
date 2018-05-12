using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeFilmTypesSeeder : BaseSeeder<FilmType>
    {
        protected override IEnumerable<FilmType> Seeds 
            => new []
            {
                new FilmType(0, "ПНД"),
                new FilmType(0, "УФА", 1),
                new FilmType(0, "123", 2)
            };
    }
}