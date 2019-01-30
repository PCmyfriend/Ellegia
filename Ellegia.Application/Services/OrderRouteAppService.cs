using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Contracts.Data.Repositories.Factories;
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
        private readonly IUserRepository _ellegiaUserRepository;

        public OrderRouteAppService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = unitOfWork.Orders;
            _orderRouteRepository = unitOfWork.OrderRoutes;
            _ellegiaUserRepository = unitOfWork.Users;
        }

        public IEnumerable<PermittedOrderRouteDto> GetPermittedRoutes(int userId)
        {
            var ellegiaUsers = _ellegiaUserRepository.GetAll();

            var permittedOrderRoutesDto = ellegiaUsers.AsEnumerable()
                .Where(u => u.Id != userId && u.Roles.Any(r => r.Name != Roles.Admin))
                .Select(_mapper.Map<PermittedOrderRouteDto>);

            return permittedOrderRoutesDto;
        }

        public OrderRouteDto AddOrderRoute(int orderId, int senderId, OrderRouteDto orderRouteDto)
        {
            if (orderRouteDto.RecipientId.Value == senderId)
                return null;

            var order = _orderRepository.GetById(orderId);

            if (order == null)
                return null;

            var orderRoute = new OrderRoute(orderRouteDto.RecipientId.Value, senderId, orderId, orderRouteDto.Comment);
            order.Send(orderRoute);

            switch (order.OrderStatus)
            {
                case OrderStatus.OnEditing:
                    var ellegiaUsers = _ellegiaUserRepository.GetUsersInRoles(new[] { Roles.Stockkeeper }).ToImmutableList();

                    if (ellegiaUsers.Any(ellegiaUser => ellegiaUser.Id == orderRouteDto.RecipientId.Value))
                        order.ChangeStatus(OrderStatus.Active);
                    break;
            }

            _unitOfWork.Complete();

            orderRoute = _orderRouteRepository.GetById(orderRoute.Id);
            return _mapper.Map<OrderRouteDto>(orderRoute); 
        }
    }
}
