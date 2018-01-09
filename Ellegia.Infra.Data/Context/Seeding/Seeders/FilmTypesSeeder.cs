using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders
{
    public class FilmTypesSeeder : BaseSeeder<FilmType>
    {
        protected override IEnumerable<FilmType> Seeds
            => new[]
            {
                new FilmType(1, "ПНД"), 
                new FilmType(2, "ПВД"),
                new FilmType(3, "Брак", 1)
            };
    }
}