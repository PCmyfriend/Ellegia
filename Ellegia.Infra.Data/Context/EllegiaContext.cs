using System.IO;
using Ellegia.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Color = Ellegia.Domain.Models.Color;

namespace Ellegia.Infra.Data.Context
{
    public class EllegiaContext : DbContext
    {
        public DbSet<Color> Colors { get; set; }

        public EllegiaContext(DbContextOptions<EllegiaContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColorEntityConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseInMemoryDatabase();
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}