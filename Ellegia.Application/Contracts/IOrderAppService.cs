using System.Collections.Generic;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Contracts 
{
    public interface IOrderAppService
    {
        OrderDto Add(int userId, OrderFormDto orderFormDto);
        IEnumerable<OrderDto> GetByType(OrderStatus orderStatus, int userId);
        byte[] GetOrderPrintingVersion(int orderId);
        bool Remove(int orderId);
    }
}