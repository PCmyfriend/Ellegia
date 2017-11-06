using Ellegia.Domain.Contracts.Common;

namespace Ellegia.Application.Contracts
{
    public interface ICommonHandbookAppService<TEntity, TEntityDto> : IAppService<TEntityDto> 
        where TEntity : class, ICommonHandbook
        where TEntityDto : class, ICommonHandbook
    {
        TEntityDto GetByName(string name);
    }
}