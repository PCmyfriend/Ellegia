using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Customer : Entity, ICommonHandbook
    {
        public ICollection<Contact> Contacts { get; private set; }
        public string Name { get; private set; }
      

        protected Customer()
        {
            // empty constructor for EF
        }
        public Customer(string name)
        {
            Name = name;
            Contacts = new Collection<Contact>();
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }
    }
}
