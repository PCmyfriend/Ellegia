using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories.Factories;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class OrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;

        public OrderAppService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = unitOfWork.Orders;
        }

        public IEnumerable<OrderDto> GetByType(OrderStatus orderStatus)
        {
            var orders = _orderRepository.GetByType(orderStatus);
            return orders?.Select(_mapper.Map<OrderDto>) ?? Enumerable.Empty<OrderDto>();          
        }

        public OrderDto Add(OrderFormDto orderFormDto)  
        {           
            var order = _mapper.Map<Order>(orderFormDto);

            _orderRepository.Add(order);
            _unitOfWork.Complete();

            order = _orderRepository.GetById(order.Id);

            return _mapper.Map<OrderDto>(order);
        }
    }
}
