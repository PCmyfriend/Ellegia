using System;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Contact : Entity, ICommonHandbook
    {
        public ContactType ContactType { get; private set; }
        public string Name { get; private set; }
        public int CustomerId { get; private set; }
        public int ContactTypeId { get; private set; }

        protected Contact()
        {
            // required by EF
        }

        public Contact(string name, ContactType contactType)
        {
            if (contactType.Validate(name))
                throw new ArgumentException(nameof(name));

            Name = name;
            ContactType = contactType;
        }

        public Contact(string name, int contactTypeId, int customerId)
        {
            Name = name;
            ContactTypeId = contactTypeId;
            CustomerId = customerId;
        }
     
    }
}
