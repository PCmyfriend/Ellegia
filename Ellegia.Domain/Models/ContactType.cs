using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class ContactType : Entity, ICommonHandbook
    {
        public string Name { get; private set; }

        public ContactType(int id, string name)
        {
            Id = id;
            Name = name;
        }
        
        protected ContactType()
        {
            // empty constructor for EF
        }
    }
}