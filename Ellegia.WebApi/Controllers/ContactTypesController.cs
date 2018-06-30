using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/contactTypes")]
    public class ContactTypesController : BaseController<ContactTypeDto, ContactTypeDto>
    {
        public ContactTypesController(IContactTypeAppService contactTypeAppService) 
            : base(contactTypeAppService)   
        {   

        }
    }
}   