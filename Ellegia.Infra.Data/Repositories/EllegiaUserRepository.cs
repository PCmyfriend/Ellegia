using System.Linq;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class EllegiaUserRepository : Repository<EllegiaUser>
    {
        public EllegiaUserRepository(EllegiaContext context) : base(context)
        {

        }

        public override IQueryable<EllegiaUser> GetAll()
        {
            return base.GetAll()
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role);
        }
    }
}
