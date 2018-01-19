using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class OrderAppService: AppService<Order, OrderFormDto, OrderDto>
    {
        public OrderAppService(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(unitOfWork.Orders, mapper, unitOfWork)
        {
        }
    }
}
