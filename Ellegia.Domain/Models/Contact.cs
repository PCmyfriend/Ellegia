using System;
using System.Collections;
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
            //if (contactType.Validate(name))
                //throw new ArgumentException(nameof(name));
            ContactTypeId = 1;
            Name = name;
            ContactType = contactType;
        }

        public Contact(string name, ContactType contactType, int contactTypeId)
        {
            //if (contactType.Validate(name))
            //throw new ArgumentException(nameof(name));
            ContactTypeId = contactTypeId;
            Name = name;
            ContactType = contactType;
        }

        public bool Equals(Contact x, Contact y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Contact obj)
        {
            throw new NotImplementedException();
        }
    }
}
