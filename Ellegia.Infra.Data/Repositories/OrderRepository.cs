using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Contracts.Data.Repositories.Factories;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EllegiaContext context) 
            : base(context)
        {
        }

        public override Order GetById(int id)
        {
            return GetAll().SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetByType(OrderStatus orderStatus)
        {
            return GetAll()
                .Where(o => o.OrderStatus == orderStatus);
        } 

        public override IQueryable<Order> GetAll()
        {
            return base.GetAll()
                .Include(o => o.Customer).ThenInclude(c => c.Contacts).ThenInclude(c => c.ContactType)
                .Include(o => o.ProductType).ThenInclude(pt => pt.FilmType)
                .Include(o => o.ProductType).ThenInclude(pt => pt.StandardSize).ThenInclude(ss => ss.PlasticBagType)
                .Include(o => o.ProductType).ThenInclude(pt => pt.FilmTypeOption)
                .Include(o => o.ProductType).ThenInclude(pt => pt.Color)
                .Include(o => o.Warehouse)
                .Include(o => o.OrderRoutes);            
        }
    }
}
