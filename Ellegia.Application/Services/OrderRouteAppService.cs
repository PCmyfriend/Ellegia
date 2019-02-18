using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Enums;
using Ellegia.Domain.Models;
using Ellegia.Infra.CrossCutting.Identity.Constants;

namespace Ellegia.Application.Services
{
    public class OrderRouteAppService : IOrderRouteAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IRepository<OrderRoute> _orderRouteRepository;
        private readonly IUserRepository _userRepository;

        public OrderRouteAppService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = unitOfWork.Orders;
            _orderRouteRepository = unitOfWork.OrderRoutes;
            _userRepository = unitOfWork.Users;
        }

        public IEnumerable<PermittedOrderRouteDto> GetPermittedRoutes(int userId)
        {
            var users = _userRepository.GetAll();

            var permittedOrderRoutesDto = users.AsEnumerable()
                .Where(u => u.Id != userId && u.Roles.Any(r => r.Name != Roles.Admin))
                .Select(_mapper.Map<PermittedOrderRouteDto>);

            return permittedOrderRoutesDto;
        }   

        public OrderRouteDto AddOrderRoute(int orderId, int senderId, OrderRouteFormDto orderRouteFormDto)
        {
            if (orderRouteFormDto.RecipientId.Value == senderId)
                return null;

            var order = _orderRepository.GetById(orderId);

            if (order == null)
                return null;

            var oldOrderStatus = order.OrderStatus;

            var recipientId = orderRouteFormDto.RecipientId.Value;
            var orderRoute = new OrderRoute(recipientId, senderId, orderId, orderRouteFormDto.Comment);
            order.Send(orderRoute);

            if (order.OrderStatus == OrderStatus.OnEditing)
            {
                var users = _userRepository
                    .GetUsersInRoles(new[] { Roles.Stockkeeper })
                    .ToImmutableList();

                if (users.Any(u => u.Id == orderRouteFormDto.RecipientId.Value))
                    order.ChangeStatus(OrderStatus.Active);
            }

            _unitOfWork.Complete();

            orderRoute = _orderRouteRepository.GetById(orderRoute.Id);
            var orderRouteDto = _mapper.Map<OrderRouteDto>(orderRoute);
            orderRouteDto.OldOrderStatus = oldOrderStatus;
            orderRouteDto.NewOrderStatus = order.OrderStatus;

            return orderRouteDto; 
        }
    }
}
