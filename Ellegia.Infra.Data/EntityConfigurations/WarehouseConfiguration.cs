using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder
                .HasMany(wh => wh.WarehouseInOutHistories)
                .WithOne()
                .HasForeignKey(w => w.WarehouseId);
        }
    }
}
