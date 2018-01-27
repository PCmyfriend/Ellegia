using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/productType")]
    public class ProductTypesController : BaseController<ProductTypeFormDto, ProductTypeDto>
    {
        public ProductTypesController(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(new ProductTypeAppService(mapper, unitOfWork))
        {

        }
    }
}
