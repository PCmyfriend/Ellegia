﻿using System.Collections.Generic;
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

            var warehouseInOutHistory = _mapper.Map<WarehouseHistoryRecord>(warehouseInOutHistoryRecordFormDto);
            warehouseInOutHistory.CreatedById = userId;

            var validateResult = warehouse.IsWarehouseInOutHistoryValid(warehouseInOutHistory);
            if (!validateResult)
                return null;

            warehouse.Add(warehouseInOutHistory);
            _unitOfWork.Complete();

            return _mapper.Map<WarehouseHistoryRecordDto>(warehouseInOutHistory);
        }

        public bool Delete(int warehouseId, WarehouseInOutHistoryRecordFormDto warehouseInOutHistoryRecordFormDto)
        {
            var warehouse = _warehouseRepository.GetById(warehouseId);

            if (warehouse == null)
                return false;

            var warehouseInOutHistory = _mapper.Map<WarehouseHistoryRecord>(warehouseInOutHistoryRecordFormDto);
                    
            var resultOfValidate = warehouse.IsWarehouseInOutHistoryValid(warehouseInOutHistory);
            if (!resultOfValidate)    
                return false;

            var isReleaseAllowed = warehouse.IsWarehouseTakeAllowed(warehouseInOutHistory);
            if (!isReleaseAllowed)
                return false;

            warehouse.Add(warehouseInOutHistory);

            _unitOfWork.Complete();

            return true;
        }
    }
}
