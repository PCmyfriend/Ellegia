using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Domain.Contracts.Data.Repositories
{
    public interface IUserRepository : IRepository<EllegiaUser>
    {       
        IEnumerable<EllegiaUser> GetUsersInRoles(string[] roleNames);

        IEnumerable<int> GetUsersIdsInRoles(string[] roleNames);  
    } 
}
        