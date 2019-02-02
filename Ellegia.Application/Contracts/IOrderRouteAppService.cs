using System.Collections.Generic;
using Ellegia.Application.Dtos;

namespace Ellegia.Application.Contracts
{   
    public interface IOrderRouteAppService
    {
        OrderRouteDto AddOrderRoute(int orderId, int senderId, OrderRouteFormDto orderRouteFormDto);
        IEnumerable<PermittedOrderRouteDto> GetPermittedRoutes(int userId);
    }
}