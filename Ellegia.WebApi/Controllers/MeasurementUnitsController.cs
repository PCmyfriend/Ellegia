using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/measurementUnits")]
    public class MeasurementUnitsController : CommonHandbookController<MeasurementUnit, MeasurementUnitDto>
    {
        public MeasurementUnitsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }
    }
}