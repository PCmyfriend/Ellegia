using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class FilmTypeConfiguration : IEntityTypeConfiguration<FilmType>
    {
        public void Configure(EntityTypeBuilder<FilmType> builder)
        {
            builder
                .HasOne(ft => ft.Parent)
                .WithMany(pft => pft.Children)
                .HasForeignKey(ft => ft.ParentId);
        }
    }
}
