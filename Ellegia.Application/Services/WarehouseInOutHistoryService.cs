using System.Collections.Generic;
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
        private readonly IRepository<WarehouseHistoryRecord> _warehouseInOutHistoryRepository;

        public WarehouseInOutHistoryService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;   
            _warehouseRepository = unitOfWork.Warehouses;
            _warehouseInOutHistoryRepository = unitOfWork.WarehouseInOutHistory;
        }

        public IEnumerable<WarehouseHistoryRecordDto> GetInOutHistory(int warehouseId)
        {
            var warehouse = _warehouseRepository.GetById(warehouseId);    

            if (warehouse == null)
                return null;

            warehouse.OrderByOperationDateTimeInOutHistory(true);
            var warehouseDto = _mapper.Map<WarehouseDto>(warehouse);
            var warehouseInOutHistoryDto = warehouseDto.InOutHistory;

            return warehouseInOutHistoryDto;
        }

        public WarehouseHistoryRecordDto Add(int userId, int warehouseId, WarehouseInOutHistoryRecordFormDto warehouseInOutHistoryRecordFormDto)
        {
            var warehouse = _warehouseRepository.GetById(warehouseId);

            if (warehouse == null)
                return null;

            var warehouseInOutHistoryRecord = _mapper.Map<WarehouseHistoryRecord>(warehouseInOutHistoryRecordFormDto);
            warehouseInOutHistoryRecord.CreatedById = userId;

            var validateResult = warehouse.IsWarehouseInOutHistoryValid(warehouseInOutHistoryRecord);
            if (!validateResult)
                return null;

            warehouse.Add(warehouseInOutHistoryRecord);
            _unitOfWork.Complete();

            warehouseInOutHistoryRecord = _warehouseInOutHistoryRepository.GetById(warehouseInOutHistoryRecord.Id);

            return _mapper.Map<WarehouseHistoryRecordDto>(warehouseInOutHistoryRecord);
        }

        public WarehouseHistoryRecordDto Delete(int warehouseId, WarehouseInOutHistoryRecordFormDto warehouseInOutHistoryRecordFormDto)
        {
            var warehouse = _warehouseRepository.GetById(warehouseId);

            if (warehouse == null)
                return null;

            var warehouseInOutHistoryRecord = _mapper.Map<WarehouseHistoryRecord>(warehouseInOutHistoryRecordFormDto);
                    
            var resultOfValidate = warehouse.IsWarehouseInOutHistoryValid(warehouseInOutHistoryRecord);
            if (!resultOfValidate)    
                return null;

            var isReleaseAllowed = warehouse.IsWarehouseReceptionAllowed(warehouseInOutHistoryRecord);
            if (!isReleaseAllowed)
                return null;

            warehouse.Add(warehouseInOutHistoryRecord);

            _unitOfWork.Complete();

            warehouseInOutHistoryRecord = _warehouseInOutHistoryRepository.GetById(warehouseInOutHistoryRecord.Id);

            return _mapper.Map<WarehouseHistoryRecordDto>(warehouseInOutHistoryRecord);
        }
    }
}
