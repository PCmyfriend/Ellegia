using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/customers")]
    public class CustomersController : BaseController<CustomerDto, CustomerDto>
    {
        public CustomersController(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(new CustomerAppService(mapper, unitOfWork))
        {

        }
    }
}
