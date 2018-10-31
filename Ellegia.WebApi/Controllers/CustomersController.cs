using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/customers")]
    public class CustomersController : BaseController<CustomerDto, CustomerDto>
    {
        public CustomersController(ICustomerAppService customerAppService) 
            : base(customerAppService)
        {

        }   
    }
}
