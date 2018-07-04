using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Contracts.Data.Repositories.Factories;
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
        private readonly IRepository<EllegiaUser> _ellegiaUserRepository;

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
            var order = _orderRepository.GetById(orderId);

            if (order == null)
                return null;

            var orderRoute = new OrderRoute(orderRouteDto.RecepientId.Value, senderId, orderId, orderRouteDto.Comment);
            _orderRouteRepository.Add(orderRoute);
         
            _unitOfWork.Complete();

            orderRoute = _orderRouteRepository.GetById(orderRoute.Id);
            return _mapper.Map<OrderRouteDto>(orderRoute); 
        }
    }
}
