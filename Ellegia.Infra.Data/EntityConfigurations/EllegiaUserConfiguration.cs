using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class EllegiaUserConfiguration : IEntityTypeConfiguration<EllegiaUser>
    {
        public void Configure(EntityTypeBuilder<EllegiaUser> builder)
        {
            builder
                .HasMany(u => u.Shifts)
                .WithOne()
                .HasForeignKey(s => s.Supervisor);
        }
    }
}
