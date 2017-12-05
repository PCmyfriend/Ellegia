using System.Collections.Generic;

namespace Ellegia.Application.Contracts
{
    public interface IAppService<TInputEntityDto, TOutputEntityDto>
        where TInputEntityDto : class
        where TOutputEntityDto : class
    {
        IEnumerable<TOutputEntityDto> GetAll();
        TOutputEntityDto GetById(int id);
        TOutputEntityDto Add(TInputEntityDto entityDto);
        TOutputEntityDto Update(TInputEntityDto entityDto);
        void Remove(int id);
    }
}