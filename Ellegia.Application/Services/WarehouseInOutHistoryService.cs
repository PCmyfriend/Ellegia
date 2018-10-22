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

        public WarehouseInOutHistoryService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;   
            _warehouseRepository = unitOfWork.Warehouses;
        }

        public IEnumerable<WarehouseHistoryRecordDto> GetFullInOutHistory(int warehouseId)
        {
            var warehouse = _warehouseRepository.GetById(warehouseId);    

            if (warehouse == null)
                return null;

            var warehouseDto = _mapper.Map<WarehouseDto>(warehouse);

            //InOutHistory
            //    .GroupBy(x => new { x.ColorId, x.FilmTypeId, x.ProductTypeId, x.MeasurementUnitId }, r => r.Amount)
            //    .Select(r => new { ColorId = r.Key.ColorId, FilmTypeId = r.Key.FilmTypeId, ProductTypeId = r.Key.ProductTypeId, Amount = r.Sum() })
            //    .ToImmutableList();

            return warehouseDto.InOutHistory;
        }


        public bool Add(int userId, int warehouseId, WarehouseHistoryRecordFormDto warehouseHistoryRecordFormDto)
        {
            var warehouse = _warehouseRepository.GetById(warehouseId);

            if (warehouse == null)
                return false;

            var warehouseInOutHistory = _mapper.Map<WarehouseHistoryRecord>(warehouseHistoryRecordFormDto);
            warehouseInOutHistory.CreatedById = userId;

            var validateResult = warehouse.IsWarehouseInOutHistoryValid(warehouseInOutHistory);
            if (!validateResult)
                return false;

            warehouse.Add(warehouseInOutHistory);

            _unitOfWork.Complete();

            return true;
        }

        public bool Delete(int warehouseId, WarehouseHistoryRecordFormDto warehouseHistoryRecordFormDto)
        {
            var warehouse = _warehouseRepository.GetById(warehouseId);

            if (warehouse == null)
                return false;

            var warehouseInOutHistory = _mapper.Map<WarehouseHistoryRecord>(warehouseHistoryRecordFormDto);
                    
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
