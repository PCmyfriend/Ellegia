using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/productTypes")]
    public class ProductTypesController : BaseController<ProductTypeFormDto, ProductTypeDto>
    {
        public ProductTypesController(IProductTypeAppService productTypeAppService) 
            : base(productTypeAppService)
        {

        }
    }
}
