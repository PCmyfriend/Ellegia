using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class ProductTypeAppService : AppService<ProductType, ProductTypeFormDto, ProductTypeDto>, IProductTypeAppService
    {
        public ProductTypeAppService(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(unitOfWork.ProductTypes, mapper, unitOfWork) 
        {

        }
    }
}
