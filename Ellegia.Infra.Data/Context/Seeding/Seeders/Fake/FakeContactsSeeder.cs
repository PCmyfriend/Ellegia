using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders.Fake
{
    public class FakeContactsSeeder : BaseSeeder<Contact>
    {
        protected override IEnumerable<Contact> Seeds
            => new[]
            {
                new Contact(
                    name: "996777123456", 
                    contactTypeId: 1, 
                    customerId: 1
                ),
                new Contact(
                    name: "pcmyfriend@yandex.com",
                    contactTypeId: 2,
                    customerId: 1
                ), 
                new Contact(
                    name: "996555123456",
                    contactTypeId: 1,
                    customerId: 2
                ), 
            };
    }
}