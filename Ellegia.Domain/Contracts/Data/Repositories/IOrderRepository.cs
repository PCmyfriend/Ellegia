using System.Collections.Generic;
using Ellegia.Domain.Enums;
using Ellegia.Domain.Models;

namespace Ellegia.Domain.Contracts.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetByType(OrderStatus orderStatus);
    }   
}
