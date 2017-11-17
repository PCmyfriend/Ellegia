using Ellegia.Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class CommonHandbookConfiguration<T> : IEntityTypeConfiguration<T> where T: class, ICommonHandbook
    {
        private readonly int _namePropertyMaxLength;

        public CommonHandbookConfiguration(int namePropertyMaxLength)
        {
            _namePropertyMaxLength = namePropertyMaxLength;
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(_namePropertyMaxLength)
                .IsRequired();

            builder.HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}