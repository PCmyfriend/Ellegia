using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Contracts.Data.Repositories.Factories;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class OrderRouteAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IRepository<OrderRoute> _orderRouteRepository;
        

        public OrderRouteAppService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = unitOfWork.Orders;
            _orderRouteRepository = unitOfWork.OrderRoutes;
        }

        public OrderRouteDto AddOrderRoute(int orderId, int senderId, OrderRouteDto orderRouteDto)
        {
            var order = _orderRepository.GetById(orderId);

            if (order == null)
                return null;

            var orderRoute = new OrderRoute(orderRouteDto.RecepientId, senderId, orderId, orderRouteDto.Comment);
            _orderRouteRepository.Add(orderRoute);
         
            _unitOfWork.Complete();

            orderRoute = _orderRouteRepository.GetById(orderRoute.Id);

            return _mapper.Map<OrderRouteDto>(orderRoute); 
        }
    }
}
