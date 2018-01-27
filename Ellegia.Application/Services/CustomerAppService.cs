using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class CustomerAppService : AppService<Customer, CustomerDto, CustomerDto>
    {
        public CustomerAppService(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(unitOfWork.Customers, mapper, unitOfWork)
        {

        }
    }
}
