using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/order")]
    public class OrderController : BaseController<OrderFormDto, OrderDto>
    {
        public OrderController(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(new OrderAppService(mapper, unitOfWork))
        {
        }
    }
}
