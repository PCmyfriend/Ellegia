using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ellegia.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Ellegia.Domain.Models
{
    public class EllegiaUser : IdentityUser<int>, IUser
    {
        public ICollection<Shift> Shifts { get; private set; }
        public int WarehouseId { get; set; }

        public EllegiaUser()
        {
            Shifts = new Collection<Shift>();
        }
    }
}