using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}