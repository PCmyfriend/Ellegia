using System.Collections.Generic;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Contact : Entity, ICommonHandbook, IEqualityComparer<Contact>
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
            Name = name;
            ContactType = contactType;
        }

        public Contact(string name, int contactTypeId, int customerId)
        {
            Name = name;
            ContactTypeId = contactTypeId;
            CustomerId = customerId;
        }

        public bool Equals(Contact x, Contact y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Contact obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
