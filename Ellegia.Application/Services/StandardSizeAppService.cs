using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class StandardSizeAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonHandbookRepository<PlasticBagType> _plasticBagTypeRepository;

        public StandardSizeAppService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _plasticBagTypeRepository = unitOfWork.PlasticBagTypes;
        }
        
        public IEnumerable<StandardSizeDto> GetAll(int plasticBagTypeId)
        {
            var plasticBagType = GetPlasticBagTypeById(plasticBagTypeId);
            
            return plasticBagType == null 
                ? Enumerable.Empty<StandardSizeDto>() 
                : plasticBagType.StandardSizes.Select(_mapper.Map<StandardSizeDto>);
        }

        public StandardSizeDto GetById(int plasticBagTypeId, int standardSizeId)
        {
            var plasticBagType = GetPlasticBagTypeById(plasticBagTypeId);
            
            return _mapper.Map<StandardSizeDto>(plasticBagType?.FindStandardSize(standardSizeId));
        }

        public StandardSizeDto Add(int plasticBagTypeId, StandardSizeDto standardSizeDto)
        {
            var plasticBagType = GetPlasticBagTypeById(plasticBagTypeId);

            if (plasticBagType == null)
                return null;
            
            var standardSize = _mapper.Map<StandardSize>(standardSizeDto);
            plasticBagType.AddStandardSize(standardSize);
            
            _unitOfWork.Complete();

            return _mapper.Map<StandardSizeDto>(standardSize);
        }

        public bool Remove(int plasticBagTypeId, int standardSizeId)
        {
            var plasticBagType = GetPlasticBagTypeById(plasticBagTypeId);

            if (plasticBagType == null || !plasticBagType.RemoveStandardSize(standardSizeId)) return false;
            
            _unitOfWork.Complete();
            return true;
        }

        private PlasticBagType GetPlasticBagTypeById(int plasticBagTypeId)
        {
            return _plasticBagTypeRepository.GetById(plasticBagTypeId);
        }
    }
}