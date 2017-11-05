using System.Collections.Generic;

namespace Ellegia.Application.Contracts
{
    public interface IAppService<TEntityDto>
    {
        IEnumerable<TEntityDto> GetAll();
        TEntityDto GetById(int id);
        TEntityDto Add(TEntityDto entityDto);
        TEntityDto Update(TEntityDto commonHandbook);
        void Remove(int id);
    }
}