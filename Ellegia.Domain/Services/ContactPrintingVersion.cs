using System.Collections.Immutable;
using System.Linq;
using Ellegia.Domain.Enums;
using Ellegia.Domain.Models;

namespace Ellegia.Domain.Services   
{
    public class ContactPrintingVersion
    {
        public ImmutableDictionary<int, string> GetContactsPrintingVersion(Customer customer)
        {
            if (!customer.Contacts.Any())
                return null;

            var contactTypes = customer.Contacts.Select(c => c.ContactType).Distinct();
            var contacts = customer.Contacts.GroupBy(c => c.ContactTypeId)
                .ToImmutableDictionary(g => g.Key, g => g.Select(c => c.Name).ToImmutableList());

            var contactsByContactTypeDictionary = contactTypes.Select(c => new
            {
                key = c.Id,
                value = string.Join(", ", contacts[c.Id])
            }).ToImmutableDictionary(g => g.key, g => g.value);

            return contactsByContactTypeDictionary;
        }

        public string GetContactPrintingVersionByContactType(
            ImmutableDictionary<int, string> contactsByContactTypeDictionary,
            FieldKeyTypeEnum fieldKeyTypeEnum)
        {
            if (!contactsByContactTypeDictionary.Any())
                return string.Empty;
       
            switch (fieldKeyTypeEnum)
            {
                case FieldKeyTypeEnum.PhoneNumber:
                    contactsByContactTypeDictionary.TryGetValue(1, out var phoneNumberPrintingVersion);
                    return phoneNumberPrintingVersion;
                case FieldKeyTypeEnum.Email:
                break;
            }

            return string.Empty;
        }
    }
}
