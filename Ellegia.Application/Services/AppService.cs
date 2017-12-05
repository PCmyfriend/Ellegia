using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;

namespace Ellegia.Application.Services
{
    public class AppService<TEntity, TInputEntityDto, TOutputEntityDto> 
        : IAppService<TInputEntityDto, TOutputEntityDto>
        where TEntity: class
        where TOutputEntityDto: class
        where TInputEntityDto: class
    {
        protected readonly IRepository<TEntity> _baseRepository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public AppService(
            IRepository<TEntity> repository, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _baseRepository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TOutputEntityDto> GetAll()
        {
            return _baseRepository.GetAll().ToImmutableList().Select(_mapper.Map<TOutputEntityDto>);
        }

        public TOutputEntityDto GetById(int id)
        {
            return _mapper.Map<TOutputEntityDto>(_baseRepository.GetById(id));
        }

        public TOutputEntityDto Add(TInputEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            
            _baseRepository.Add(entity);
            _unitOfWork.Complete();

            return _mapper.Map<TOutputEntityDto>(entity);
        }

        public TOutputEntityDto Update(TInputEntityDto entityDto)
        {
            throw new NotSupportedException();
        }

        public void Remove(int id)
        {
            _baseRepository.Remove(id);
            _unitOfWork.Complete();
        }
    }
}