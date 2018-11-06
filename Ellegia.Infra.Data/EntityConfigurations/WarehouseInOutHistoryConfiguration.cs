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
                .HasOne(whr => whr.MeasurementUnit)
                .WithMany()
                .HasForeignKey(whr => whr.MeasurementUnitId);

            builder
                .HasOne(whr => whr.Color)
                .WithMany()
                .HasForeignKey(whr => whr.ColorId);

            builder
                .HasOne(whr => whr.Shift)
                .WithMany()
                .HasForeignKey(whr => whr.ShiftId);

            builder
                .HasOne(whr => whr.Order)
                .WithMany()
                .HasForeignKey(whr => whr.OrderId);

            builder
                .HasOne(whr => whr.ProductType)
                .WithMany()
                .HasForeignKey(whr => whr.ProductTypeId);

            builder
                .HasOne(whr => whr.FilmType)
                .WithMany()
                .HasForeignKey(whr => whr.FilmTypeId);

            builder
                .HasOne(whr => whr.Customer)
                .WithMany()
                .HasForeignKey(whr => whr.CustomerId);

            builder.Ignore(whr => whr.FormattedOperationDateTime);
            builder.Ignore(whr => whr.Name);
            builder.Ignore(whr => whr.Type);
        }
    }
}