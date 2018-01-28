using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/plasticBagTypes")]
    public class PlasticBagTypesController : CommonHandbookController<PlasticBagType, PlasticBagTypeDto>
    {
        public PlasticBagTypesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }
    }
}