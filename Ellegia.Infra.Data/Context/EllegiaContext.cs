using System;
using System.IO;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context.Extensions;
using Ellegia.Infra.Data.Context.Seeding;
using Ellegia.Infra.Data.Context.Seeding.Seeders;
using Ellegia.Infra.Data.Context.Seeding.Seeders.Fake;
using Ellegia.Infra.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FilmType = Ellegia.Domain.Models.FilmType;
using PlasticBagType = Ellegia.Domain.Models.PlasticBagType;


namespace Ellegia.Infra.Data.Context
{
    public class EllegiaContext 
        : IdentityDbContext<EllegiaUser, EllegiaRole, int, IdentityUserClaim<int>,
            EllegiaUserRole, IdentityUserLogin<int>, 
            IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Color> Colors { get; set; }
        public DbSet<PlasticBagType> PlasticBagTypes { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }    
        public DbSet<FilmType> FilmTypes { get; set; }
        public DbSet<FilmTypeOption> FilmTypesOptions { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<StandardSize> StandardSizes { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }

        public EllegiaContext(DbContextOptions<EllegiaContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<Color>(100));
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<MeasurementUnit>(100));
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<FilmType>(100));
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<FilmTypeOption>(100));
            modelBuilder.ApplyConfiguration(new CommonHandbookConfiguration<Shift>(255));
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());            
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EllegiaUserConfiguration());
            modelBuilder.ApplyConfiguration(new EllegiaUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new FilmTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlasticBagTypeConfiguration(255));
            modelBuilder.ApplyConfiguration(new StandardSizeConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseInMemoryDatabase("EllegiaDb");
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            optionsBuilder.UseOpenIddict<int>();
        }
        
        public static void Seed(IServiceProvider serviceProvider, IConfigurationRoot configuration)
        {
            var context = serviceProvider.GetRequiredService<EllegiaContext>();
            
            context.EnsureSeeded(new ISeeder[]
            {
                new EllegiaRolesSeeder(),
                new ContactTypesSeeder(),
                new WarehousesSeeder(),
                new FakeCustomersSeeder(), 
                new FakeContactsSeeder(), 
                new FakeFilmTypesSeeder(), 
                new FakeFilmTypeOptionsSeeder(), 
                new FakeColorsSeeder(),
                new FakePlasticBagTypesSeeder(), 
                new FakeStandardSizesSeeder()
            });

            context.EnsureSeeded(serviceProvider, new (string userName, string userRole, string email, string password)[]
            {
                (configuration["Users:Admin:Name"], configuration["Users:Admin:Role"], configuration["Users:Admin:Email"], configuration["Users:Admin:Password"]),
                (configuration["Users:Secretary:Name"], configuration["Users:Secretary:Role"], configuration["Users:Secretary:Email"], configuration["Users:Secretary:Password"]),
                (configuration["Users:Technologist:Name"], configuration["Users:Technologist:Role"], configuration["Users:Technologist:Email"], configuration["Users:Technologist:Password"]),
                (configuration["Users:Stockkeeper:Name"], configuration["Users:Stockkeeper:Role"], configuration["Users:Stockkeeper:Email"], configuration["Users:Stockkeeper:Password"])
            });
        }
    }
}