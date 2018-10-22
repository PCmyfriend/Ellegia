using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class WarehouseInOutHistoryConfiguration : IEntityTypeConfiguration<WarehouseHistoryRecord>
    {
        public void Configure(EntityTypeBuilder<WarehouseHistoryRecord> builder)
        {
            builder
                .HasOne(c => c.MeasurementUnit)
                .WithMany()
                .HasForeignKey(c => c.MeasurementUnitId);

            builder
                .HasOne(c => c.Color)
                .WithMany()
                .HasForeignKey(c => c.ColorId);

            builder
                .HasOne(c => c.Shift)
                .WithMany()
                .HasForeignKey(c => c.ShiftId);

            builder
                .HasOne(c => c.Order)
                .WithMany()
                .HasForeignKey(c => c.OrderId);

            builder
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.ProductTypeId);

            builder
                .HasOne(c => c.FilmType)
                .WithMany()
                .HasForeignKey(c => c.FilmTypeId);

            builder
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId);
        }
    }
}