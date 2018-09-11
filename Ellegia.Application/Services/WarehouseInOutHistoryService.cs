using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class WarehouseInOutHistoryService : IWarehouseInOutHistoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Warehouse> _warehouseRepository;

        public WarehouseInOutHistoryService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;   
            _warehouseRepository = unitOfWork.Warehouses;
        }

        public bool Add(int warehouseId, WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto)
        {
            var warehouse = _warehouseRepository.GetById(warehouseId);

            if (warehouse == null)
                return false;

            var warehouseInOutHistory = _mapper.Map<WarehouseInOutHistory>(warehouseInOutHistoryFormDto);

            var validateResult = warehouse.IsWarehouseInOutHistoryValid(warehouseInOutHistory);
            if (!validateResult)
                return false;

            warehouse.Accept(warehouseInOutHistory);

            _unitOfWork.Complete();

            return true;
        }

        public bool Delete(int warehouseId, WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto)
        {
            var warehouse = _warehouseRepository.GetById(warehouseId);

            if (warehouse == null)
                return false;

            var warehouseInOutHistory = _mapper.Map<WarehouseInOutHistory>(warehouseInOutHistoryFormDto);
                    
            var resultOfValidate = warehouse.IsWarehouseInOutHistoryValid(warehouseInOutHistory);
            if (!resultOfValidate)    
                return false;

            var isReleaseAllowed = warehouse.IsWarehouseTakeAllowed(warehouseInOutHistory);
            if (!isReleaseAllowed)
                return false;

            warehouse.Accept(warehouseInOutHistory);

            _unitOfWork.Complete();

            return true;
        }
    }
}
