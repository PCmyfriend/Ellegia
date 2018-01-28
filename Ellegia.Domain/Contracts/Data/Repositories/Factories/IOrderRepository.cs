using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Domain.Contracts.Data.Repositories.Factories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetByType(OrderStatus orderStatus);
    }   
}
