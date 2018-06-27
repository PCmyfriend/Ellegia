using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class ShiftAppService : IShiftAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Warehouse> _warehouseRepository;
        
        public ShiftAppService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _warehouseRepository = unitOfWork.Warehouses;
        }

        public IEnumerable<ShiftDto> GetAll(int warehouseId, int employeeId)
        {
            var warehouse = GetWarehouseById(warehouseId);

            if (warehouse == null)
                return Enumerable.Empty<ShiftDto>();

            var shifts = warehouse.Employees
                .SelectMany(e => e.Shifts)
                .Where(e => e.Id == employeeId);

            return warehouse.Employees == null
                ? Enumerable.Empty<ShiftDto>()
                : shifts.Select(_mapper.Map<ShiftDto>);
        }
                
        private Warehouse GetWarehouseById(int warehouseId)
        {
            return _warehouseRepository.GetById(warehouseId);
        }
    }
}
