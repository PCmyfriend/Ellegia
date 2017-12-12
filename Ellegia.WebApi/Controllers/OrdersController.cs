using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos.Order;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/orders")]
    public class OrdersController : BaseController<OrderFormDto, OrderDto>
    {
        private readonly IOrderAppService _orderAppService;
        
        public OrdersController(IOrderAppService orderAppService) 
            : base(orderAppService)
        {
            _orderAppService = (IOrderAppService) _baseAppService;
        }

        [HttpGet("active")]
        public IActionResult GetActive() => Ok(_orderAppService.GetActive());
    }
}