using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class ProductTypeAppService : AppService<ProductType, ProductTypeDto, ProductTypeDto>
    {
        public ProductTypeAppService(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(unitOfWork.ProductTypes, mapper, unitOfWork)
        {
        }
    }
}
