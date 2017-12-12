using System.Collections.Generic;
using Ellegia.Application.Dtos.Order;

namespace Ellegia.Application.Contracts
{
    public interface IOrderAppService : IAppService<OrderFormDto, OrderDto>
    {
        IEnumerable<OrderDto> GetActive();
    }
}