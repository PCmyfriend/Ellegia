using System.Linq;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(EllegiaContext context) : base(context)
        {

        }

        public override IQueryable<Order> GetAll()
        {
            return base.GetAll()
                .Include(o => o.Customer)    
                .Include(o => o.ProductType)
                .Include(o => o.Warehouse);
        }
    }
}
