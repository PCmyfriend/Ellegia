using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;

namespace Ellegia.Application.Services
{
    public class CommonHandbookAppService<TEntity, TEntityDto> 
        : AppService<TEntity, TEntityDto, TEntityDto>, 
          ICommonHandbookAppService<TEntityDto>
        where TEntity : class, ICommonHandbook 
        where TEntityDto: class, ICommonHandbook
    {
        private readonly ICommonHandbookRepository<TEntity> _commonHandbookRepository;

        public CommonHandbookAppService(IMapper mapper, IUnitOfWork unitOfWork)
            : base(unitOfWork.CreateCommonHandbookRepository<TEntity>(), mapper, unitOfWork)
        {
            _commonHandbookRepository = (ICommonHandbookRepository<TEntity>) _baseRepository;
        }
        
        public TEntityDto GetByName(string name)
        {
            return _mapper.Map<TEntityDto>(_commonHandbookRepository.GetByName(name));
        }
    }
}