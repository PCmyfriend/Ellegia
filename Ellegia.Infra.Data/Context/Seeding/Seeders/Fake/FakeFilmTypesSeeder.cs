using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeFilmTypesSeeder : BaseSeeder<FilmType>
    {
        protected override IEnumerable<FilmType> Seeds 
            => new []
            {
                new FilmType("ПНД"),
                new FilmType("УФА", 1),
                new FilmType("123", 2)
            };
    }
}