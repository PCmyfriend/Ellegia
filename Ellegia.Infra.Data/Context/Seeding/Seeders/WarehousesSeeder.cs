using System.Collections.Generic;
using Ellegia.Domain.Models;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders
{
    public class WarehousesSeeder : BaseSeeder<Warehouse>
    {
        protected override IEnumerable<Warehouse> Seeds => new[]
        {
            new Warehouse(1, "Склад №1")
        };
    }
}
