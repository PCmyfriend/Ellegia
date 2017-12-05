using System.Collections.Generic;
using System.Linq;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EllegiaContext context) : base(context)
        {
        }

        public override Order GetById(int id)
        {
            return GetAll().SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetActive()
        {
            return GetAll().Where(o => o.IsActive);
        }

        public override IQueryable<Order> GetAll()
        {
            return base.GetAll()
                .Include(o => o.Specifications).ThenInclude(s => s.Color)
                .Include(o => o.Specifications).ThenInclude(s => s.FilmType)
                .Include(o => o.Specifications).ThenInclude(s => s.StandardSize)
                .Include(o => o.Specifications).ThenInclude(s => s.StandardSize).ThenInclude(ss => ss.PlasticBagType)
                .Include(o => o.Specifications).ThenInclude(s => s.FilmTypeOption)
                .Include(o => o.PaymentInfo);
        }
    }
}