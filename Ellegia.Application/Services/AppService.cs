using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;

namespace Ellegia.Application.Services
{
    public class AppService<TEntity, TEntityDto> 
        where TEntity: class
        where TEntityDto: class
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<TEntity> _repository;

        public AppService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = CreateRepository();
        }

        public IEnumerable<TEntityDto> GetAll()
        {
            return _repository.GetAll().ToImmutableList().Select(_mapper.Map<TEntityDto>);
        }

        public TEntityDto GetById(int id)
        {
            return _mapper.Map<TEntityDto>(_repository.GetById(id));
        }

        public TEntityDto Add(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            
            _repository.Add(entity);
            _unitOfWork.Complete();

            return _mapper.Map<TEntityDto>(entity);
        }

        public TEntityDto Update(TEntityDto entityDto)
        {
            throw new NotSupportedException();
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
            _unitOfWork.Complete();
        }
        
        protected virtual IRepository<TEntity> CreateRepository()
        {
            return _unitOfWork.CreateRepository<TEntity>();
        }
    }
}