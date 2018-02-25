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
        protected readonly IRepository<TEntity> BaseRepository;
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;

        public AppService(
            IRepository<TEntity> repository, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            BaseRepository = repository;
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<TOutputEntityDto> GetAll()
        {
            return BaseRepository.GetAll().ToImmutableList().Select(Mapper.Map<TOutputEntityDto>);
        }

        public TOutputEntityDto GetById(int id)
        {
            return Mapper.Map<TOutputEntityDto>(BaseRepository.GetById(id));
        }

        public TOutputEntityDto Add(TInputEntityDto entityDto)
        {
            var entity = Mapper.Map<TEntity>(entityDto);
            
            BaseRepository.Add(entity);
            UnitOfWork.Complete();

            return Mapper.Map<TOutputEntityDto>(entity);
        }

        public TOutputEntityDto Update(TInputEntityDto entityDto)
        {
            throw new NotSupportedException();
        }

        public void Remove(int id)
        {
            BaseRepository.Remove(id);
            UnitOfWork.Complete();
        }
    }
}