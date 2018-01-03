using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Customer : Entity
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

        public Contact FindContact(int id)
        {
            return Contacts.SingleOrDefault(ss => ss.Id == id);
        }
            
        public bool RemoveContact(int id)   
        {
            var contact = FindContact(id);
            return contact != null && Contacts.Remove(contact);
        }
    }
}
