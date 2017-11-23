using System.IO;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
    

namespace Ellegia.Infra.Data.Context
{
    public class EllegiaContext : DbContext
    {
        public DbSet<Color> Colors { get; set; }
        public DbSet<PlasticBagType> PlasticBagTypes { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }    
        public DbSet<FilmType> FilmTypes { get; set; }
        public DbSet<FilmTypeOption> FilmTypesOptions { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<StandardSize> StandardSizes { get; set; }

        public EllegiaContext(DbContextOptions<EllegiaContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<Color>(100));
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<ContactType>(100));
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<MeasurementUnit>(100));
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<FilmType>(100));
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<FilmTypeOption>(100));
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<Shift>(255));
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<OrderStatus>(255));

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseInMemoryDatabase("EllegiaDb");
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}