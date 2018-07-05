using System.Collections.Immutable;
using System.Linq;
using Ellegia.Domain.Enums;
using Ellegia.Domain.Models;

namespace Ellegia.Domain.Services.PdfFileIO   
{   
    public class OrderPrintingVersion
    {             
        public string GetGeneralInfoPrintingVersion(Order order)
        {
            var quantityInKg = $"{order.QuantityInKg} кг.";
            return quantityInKg;
        }        

        public (string thicknessInMicron, string hasCorona) GetProductTypePrintingVersion(ProductType productType)
        {
            var thicknessInMicron = $"{productType.ThicknessInMicron} мк.";
            var hasCorona = productType.HasCorona ? "Имеется" : "Отсутствует";
            return (thicknessInMicron, hasCorona);
        }
        
        public (string widthInMm, string lengthInMm) GetStandardSizePrintingVersion(StandardSize standardSize)
        {
            var widthInMm = $"{standardSize.WidthInMm} мм.";
            var lengthInMm = $"{standardSize.HeightInMm} мм.";

            return (widthInMm, lengthInMm);
        }

        public (string phoneNumber, string email) GetContactsPrintingVersion(Customer customer)
        {
            if (!customer.Contacts.Any())
                return (string.Empty, string.Empty);

            var contactTypes = customer.Contacts.Select(c => c.ContactType).Distinct();
            var contacts = customer.Contacts.GroupBy(c => c.ContactTypeId)
                .ToImmutableDictionary(g => g.Key, g => g.Select(c => c.Name).ToImmutableList());

            var contactsByContactTypeDictionary = contactTypes.Select(c => new
            {
                key = c.ContactTypeEnum,
                value = string.Join(", ", contacts[c.Id])
            }).ToImmutableDictionary(g => g.key, g => g.value); 

            contactsByContactTypeDictionary.TryGetValue(ContactTypeEnum.PhoneNumber, out var phoneNumber);
            contactsByContactTypeDictionary.TryGetValue(ContactTypeEnum.Email, out var email);

            return (phoneNumber ?? string.Empty, email ?? string.Empty);
        }   
    }
}
