using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder
                .HasOne(p => p.Color)
                .WithMany()
                .HasForeignKey(p => p.ColorId);

            builder
                .HasOne(p => p.FilmTypeOption)
                .WithMany()
                .HasForeignKey(p => p.FilmTypeOptionId);

            builder
                .HasOne(p => p.StandardSize)
                .WithMany()
                .HasForeignKey(p => p.StandardSizeId);

            builder
                .HasOne(p => p.FilmType)
                .WithMany()
                .HasForeignKey(p => p.FilmTypeId);


        }
    }
}
