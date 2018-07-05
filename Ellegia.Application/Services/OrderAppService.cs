using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories.Factories;
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
        }

        public IEnumerable<OrderDto> GetByType(OrderStatus orderStatus, int userId)
        {
            var orders = _orderRepository.GetByType(orderStatus).ToImmutableList();

            var permittedOrderRecipients = _unitOfWork.Users.GetAll()
                .AsEnumerable()
                .Where(u => u.Id != userId && u.Roles.All(r => r.NormalizedName != Roles.AdminNormalizedName))
                .Select(_mapper.Map<PermittedOrderRouteDto>)
                .ToImmutableList();

            var userOrders = orders
                .Where(o => o.HolderId == userId)
                .Select(_mapper.Map<OrderDto>)
                .Select(o =>
                {
                    o.IsMine = true;
                    o.PermittedRoutes = permittedOrderRecipients;
                    return o;
                });
                
            var otherOrders = orders
                .Where(o => o.HolderId != userId)
                .Select(_mapper.Map<OrderDto>);

            return userOrders.Union(otherOrders);
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