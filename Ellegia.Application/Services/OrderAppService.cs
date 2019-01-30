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
using Ellegia.Domain.Services.PdfFileIO.PdfFileReader;
using Ellegia.Domain.Services.PdfFileIO.PdfFileWriter;
using Ellegia.Infra.CrossCutting.Identity.Constants;

namespace Ellegia.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IPdfFileReader _pdfFileReader;
        private readonly IPdfFileWriter _pdfFileWriter;
        private readonly IUserRepository _ellegiaUserRepository;

        public OrderAppService(
            IMapper mapper,
            IUnitOfWork unitOfWork, 
            IPdfFileReader pdfFileReader,
            IPdfFileWriter pdfFileWriter)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = unitOfWork.Orders;
            _pdfFileReader = pdfFileReader;
            _pdfFileWriter = pdfFileWriter;
            _ellegiaUserRepository = unitOfWork.Users;
        }

        public IEnumerable<OrderDto> GetByType(OrderStatus orderStatus, int userId)
        {
            IEnumerable<Order> orders;

            if (orderStatus == OrderStatus.Active || orderStatus == OrderStatus.ActivePartiallyReleased)
            {
                var activerOrders = _orderRepository.GetByType(OrderStatus.Active).ToImmutableList();
                var activePartiallyReleasedOrders = _orderRepository.GetByType(OrderStatus.ActivePartiallyReleased).ToImmutableList();
                orders = activerOrders.AddRange(activePartiallyReleasedOrders);
            }     
            else
                orders = _orderRepository.GetByType(orderStatus).ToImmutableList();

            if (!orders.Any())
                return Enumerable.Empty<OrderDto>();

            var ellegiaUser = _ellegiaUserRepository.GetById(userId);

            //подозрительная конструкция
            var permittedOrderRecipients = _ellegiaUserRepository.GetAll().AsEnumerable()
                .Where(u => u.Id != userId && u.Roles.All(r => r.Name != Roles.Admin))
                .Select(_mapper.Map<PermittedOrderRouteDto>).ToImmutableList();

            var ellegiaUsers = _ellegiaUserRepository.GetUsersInRoles(new[]
            {
                Roles.Admin,
                Roles.Technologist,
                Roles.Manager
            }).ToImmutableList();

            var orderDtos = orders.Where(o => o.IsAviableForUser(ellegiaUser.Id)).Select(o =>
            {
                var orderDto = Mapper.Map<OrderDto>(o);

                if (o.HolderId == userId)
                {
                    orderDto.IsMine = true;
                    orderDto.PermittedRoutes = permittedOrderRecipients;
                }

                if (o.IsDeletionPermitted(ellegiaUsers))
                    orderDto.IsDeletionPermitted = true;

                if (ellegiaUser.HasRole(Roles.StockkeeperNormalizedName))
                    orderDto.IsCompletionPermitted = true;

                return orderDto;
            }).ToImmutableList();

            return orderDtos;
        }

        public OrderDto Add(int userId, OrderFormDto orderFormDto)
        {
            var order = _mapper.Map<Order>(orderFormDto);

            order.Send(new OrderRoute(userId, userId, order.Id, string.Empty));

            _orderRepository.Add(order);
            _unitOfWork.Complete();

            order = _orderRepository.GetById(order.Id);

            return _mapper.Map<OrderDto>(order);
        }

        public bool Remove(int orderId)
        {
            var order = _orderRepository.GetById(orderId);

            if (order == null) return false;

            _orderRepository.Remove(orderId);
            _unitOfWork.Complete();

            return true;
        }

        public byte[] GetOrderPrintingVersion(int orderId)
        {
            var order = _orderRepository.GetById(orderId);      
            if (order == null)    
                return null;

            var pdfReader = _pdfFileReader.ReadFile();
            return _pdfFileWriter.FillPfdTemplate(pdfReader, order);
        }
    }
}