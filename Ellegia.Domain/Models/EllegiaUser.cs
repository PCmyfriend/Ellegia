using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Ellegia.Domain.Models
{   
    public class EllegiaUser : IdentityUser<int>
    {
        public ICollection<EllegiaUserRole> UserRoles { get; private set; }
        public ICollection<Shift> Shifts { get; private set; }
        public Warehouse Warehouse { get; private set; }
        public int WarehouseId { get; private set; }

        public string FullName { get; set; }

        public EllegiaUser()
        {
            UserRoles = new Collection<EllegiaUserRole>();
            Shifts = new Collection<Shift>();
        }

        public void AddShift(Shift shift)
        {
            Shifts.Add(shift);  
        }
                
        public bool HasRole(string normalizedName)
        {
            return Roles.Any(r => r.NormalizedName == normalizedName);
        }

        [NotMapped]
        public ICollection<EllegiaRole> Roles
            => UserRoles.Select(ur => ur.Role).ToImmutableList();


    }
}