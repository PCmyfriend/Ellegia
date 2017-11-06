using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;

namespace Ellegia.Application.Services
{
    public class CommonHandbookAppService<TEntity, TEntityDto> : ICommonHandbookAppService<TEntity, TEntityDto> 
        where TEntity : class, ICommonHandbook 
        where TEntityDto: class, ICommonHandbook
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonHandbookRepository<TEntity> _commonHandbookRepository;

        public CommonHandbookAppService(IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _commonHandbookRepository = _unitOfWork.CreateRepository<TEntity>();
        }
        
        public IEnumerable<TEntityDto> GetAll()
        {
            return _commonHandbookRepository.GetAll().ToImmutableList().Select(_mapper.Map<TEntityDto>);
        }

        public TEntityDto GetById(int id)
        {
            return _mapper.Map<TEntityDto>(_commonHandbookRepository.GetById(id));
        }
        
        public TEntityDto GetByName(string name)
        {
            return _mapper.Map<TEntityDto>(_commonHandbookRepository.GetByName(name));
        }

        public TEntityDto Add(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            
            _commonHandbookRepository.Add(entity);
            _unitOfWork.Complete();

            return _mapper.Map<TEntityDto>(entity);
        }

        public TEntityDto Update(TEntityDto commonHandbook)
        {
            throw new NotSupportedException();
        }

        public void Remove(int id)
        {
            _commonHandbookRepository.Remove(id);
            _unitOfWork.Complete();
        }
    }
}