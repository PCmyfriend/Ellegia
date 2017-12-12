using Ellegia.Domain.Contracts.Common;

namespace Ellegia.Application.Contracts
{
    public interface ICommonHandbookAppService<TEntityDto> : IAppService<TEntityDto, TEntityDto> 
        where TEntityDto : class, ICommonHandbook
    {
        TEntityDto GetByName(string name);
    }
}