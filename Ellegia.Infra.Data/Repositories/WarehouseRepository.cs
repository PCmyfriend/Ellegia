using System.Linq;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class WarehouseRepository : Repository<Warehouse>
    {
        public WarehouseRepository(EllegiaContext context) : base(context)
        {

        }

        public override IQueryable<Warehouse> GetAll()
        {
            return base.GetAll()
                .Include(w => w.Employees)
                .ThenInclude(s => s.Shifts);
        }
    }
}
