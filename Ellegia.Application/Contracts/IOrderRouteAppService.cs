using System.Collections.Generic;
using Ellegia.Application.Dtos;

namespace Ellegia.Application.Contracts
{   
    public interface IOrderRouteAppService
    {
        OrderRouteDto AddOrderRoute(int orderId, int senderId, OrderRouteDto orderRouteDto);
        IEnumerable<PermittedOrderRouteDto> GetPermittedRoutes(int userId);
    }
}