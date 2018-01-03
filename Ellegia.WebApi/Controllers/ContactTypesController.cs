using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/contactTypes")]
    public class ContactTypesController : BaseController<ContactTypeDto, ContactTypeDto>
    {
        public ContactTypesController(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(new ContactTypeAppService(mapper, unitOfWork))
        {

        }
    }
}