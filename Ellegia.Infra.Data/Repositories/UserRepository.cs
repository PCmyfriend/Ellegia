using System.Collections.Generic;
using System.Linq;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class UserRepository : Repository<EllegiaUser>, IUserRepository
    {
        public UserRepository(EllegiaContext context) : base(context)
        {
        }

        public override IQueryable<EllegiaUser> GetAll()
        {
            return base.GetAll()
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role);
        }

        public IEnumerable<EllegiaUser> GetUsersInRoles(string[] roleNames)
        {
            return GetAll().AsEnumerable().Where(u => u.Roles.Any(r => roleNames.Contains(r.Name)));
        }
    }
}   