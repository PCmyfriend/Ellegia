﻿using System.Linq;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(EllegiaContext context) : base(context)
        {

        }

        public override Warehouse GetById(int id)
        {
            return GetAll() 
                .SingleOrDefault(w => w.Id == id);
        }

        public override IQueryable<Warehouse> GetAll()
        {
            return base.GetAll()
                .Include(w => w.InOutHistory)
                    .ThenInclude(whr => whr.ProductType)
                    .ThenInclude(whr => whr.FilmType)
                    .ThenInclude(whr => whr.Children)
                .Include(w => w.InOutHistory)
                    .ThenInclude(whr => whr.ProductType)
                    .ThenInclude(whr => whr.StandardSize)
                    .ThenInclude(whr => whr.PlasticBagType)
                .Include(w => w.InOutHistory)
                    .ThenInclude(whr => whr.ProductType)
                    .ThenInclude(whr => whr.FilmTypeOption)
                .Include(w => w.InOutHistory)
                    .ThenInclude(whr => whr.FilmType)
                    .ThenInclude(whr => whr.Children)
                .Include(w => w.InOutHistory)
                    .ThenInclude(whr => whr.Order)
                    .ThenInclude(o => o.Customer)
                .Include(w => w.InOutHistory)
                    .ThenInclude(whr => whr.Order)
                    .ThenInclude(o => o.ProductType)
                .Include(w => w.InOutHistory)
                    .ThenInclude(whr => whr.MeasurementUnit)
                .Include(w => w.InOutHistory)
                    .ThenInclude(whr => whr.Shift)
                .Include(w => w.InOutHistory)
                    .ThenInclude(whr => whr.Color)
                .Include(w => w.InOutHistory)
                    .ThenInclude(whr => whr.Customer);
        }
    }
}
