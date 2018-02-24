using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Core.Services;
using Ellegia.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private readonly OrderAppService _orderAppService;
        private readonly UserManager<EllegiaUser> _userManager;
        private readonly IHostingEnvironment _appEnvironment;

        public OrdersController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<EllegiaUser> userManager, ITextFileReader textFileReader, IHostingEnvironment appEnvironment)
        {
            _orderAppService = new OrderAppService(mapper, unitOfWork, textFileReader);
            _userManager = userManager;
            _appEnvironment = appEnvironment;
        }

        [HttpGet("{orderStatus}")]
        public IActionResult GetByType(string orderStatus)
        {
            if (!Enum.TryParse(orderStatus, true, out OrderStatus outOrderStatus))
                return BadRequest();

            return Ok(_orderAppService.GetByType(outOrderStatus));
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderFormDto orderFormDto)
        { 
            var orderDto = _orderAppService.Add(orderFormDto);
            return StatusCode(StatusCodes.Status201Created, orderDto);
        }   

        [Route("/api/orders/{orderId}/printingVersion")]
        public IActionResult GetOrderPrintingVersion(int orderId)
        {
            //_orderAppService.GetOrderPrintingVersion(orderId);
            var existingFileStream = new FileStream(Directory.GetCurrentDirectory() + "\\wwwroot\\orderTemplate.pdf",
                FileMode.Open);

            var response = File(existingFileStream, "application/octet-stream"); // FileStreamResult
            return response;
        }
    }
}
