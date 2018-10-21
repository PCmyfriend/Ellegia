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

        public override Warehouse GetById(int id)
        {
            return GetAll() 
                .SingleOrDefault(w => w.Id == id);
        }

        public override IQueryable<Warehouse> GetAll()
        {
            return base.GetAll()
                .Include(wh => wh.InOutHistory)
                .Include(w => w.Employees)
                .ThenInclude(s => s.Shifts);

        }
    }
}
