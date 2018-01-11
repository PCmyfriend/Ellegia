using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Warehouse: Entity
    {
        public ICollection<EllegiaUser> Employees { get; private set; }

        public string Name { get; private set; }

        protected Warehouse()
        {
            Employees = new Collection<EllegiaUser>();
        }

        public Warehouse(int id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }
    }
}
