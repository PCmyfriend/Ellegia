using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class ColorAppService : IColorAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorAppService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<ColorDto> GetAll()
        {
            return _unitOfWork.Colors.GetAll().ToImmutableList().Select(_mapper.Map<ColorDto>);
        }

        public ColorDto GetById(int id)
        {
            return _mapper.Map<ColorDto>(_unitOfWork.Colors.GetById(id));
        }
        
        public ColorDto Add(ColorDto entityDto)
        {
            var color = _mapper.Map<Color>(entityDto);
            
            _unitOfWork.Colors.Add(color);
            _unitOfWork.Complete();

            return _mapper.Map<ColorDto>(color);
        }

        public ColorDto Update(ColorDto entityDto)
        {
            throw new NotSupportedException();
        }

        public void Remove(int id)
        {
            _unitOfWork.Colors.Remove(id);
            _unitOfWork.Complete();
        }
    }
}