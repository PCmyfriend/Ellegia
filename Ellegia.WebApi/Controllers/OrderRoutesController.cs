using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Authorize]
    [Route("api/orders/{orderId}/routes")]
    public class OrderRoutesController : Controller
    {
        private readonly OrderRouteAppService _orderAppService;
        private readonly UserManager<EllegiaUser> _userManager;

        public OrderRoutesController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<EllegiaUser> userManager)
        {
            _orderAppService = new OrderRouteAppService(mapper, unitOfWork);
            _userManager = userManager;
        }


        [HttpPost]      
        public IActionResult AddOrderRoute(int orderId, OrderRouteDto orderRouteDto)
        {
            var userId = _userManager.GetUserId(User);

            if (!int.TryParse(userId, out int parsedUserId))
                return BadRequest();

           orderRouteDto = _orderAppService.AddOrderRoute(orderId, parsedUserId, orderRouteDto);

            if (orderRouteDto == null)
                return BadRequest();

           return StatusCode(StatusCodes.Status201Created, orderRouteDto);      
        }

    }
}
