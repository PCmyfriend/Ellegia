using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos.Order;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class OrderAppService : AppService<Order, OrderFormDto, OrderDto>, IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderAppService(
            IMapper mapper, 
            IUnitOfWork unitOfWork) 
            : base(unitOfWork.Orders, mapper, unitOfWork)
        {
            _orderRepository = (IOrderRepository) _baseRepository;
        }

        public IEnumerable<OrderDto> GetActive()
        {
            return _orderRepository.GetActive().ToImmutableList().Select(_mapper.Map<OrderDto>);
        }
    }
}