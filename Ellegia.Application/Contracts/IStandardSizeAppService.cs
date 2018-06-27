using System.Collections.Generic;
using Ellegia.Application.Dtos;

namespace Ellegia.Application.Contracts
{   
    public interface IStandardSizeAppService
    {
        StandardSizeDto Add(int plasticBagTypeId, StandardSizeDto standardSizeDto);
        IEnumerable<StandardSizeDto> GetAll(int plasticBagTypeId);
        StandardSizeDto GetById(int plasticBagTypeId, int standardSizeId);
        bool Remove(int plasticBagTypeId, int standardSizeId);
    }
}