using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/colors")]
    public class ColorsController : CommonHandbookController<Color, ColorDto>
    {
        public ColorsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }
    }
}