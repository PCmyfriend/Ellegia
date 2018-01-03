using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders
{
    public class ContactTypesSeeder : BaseSeeder<ContactType>
    {
        protected override IEnumerable<ContactType> Seeds
            => new[]
            {
                new ContactType(1, "Телефонный номер", "^[0-9]*$"),
                new ContactType(2, "Email", ".")
            };
    }
}