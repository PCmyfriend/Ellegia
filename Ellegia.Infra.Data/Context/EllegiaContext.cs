using System;
using System.IO;
using System.Threading.Tasks;
using Ellegia.Domain.Models;
using Ellegia.Infra.CrossCutting.Identity.Models;
using Ellegia.Infra.Data.Context.Extensions;
using Ellegia.Infra.Data.Context.Seeding.Seeders;
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
    public class EllegiaContext : IdentityDbContext<EllegiaUser, EllegiaRole, int>
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

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());


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

            optionsBuilder.UseOpenIddict<int>();
        }
        
        public static async Task CreateAdminAccount(
            IServiceProvider serviceProvider,
            IConfigurationRoot configuration)
        {
            var userManager =
                serviceProvider.GetRequiredService<UserManager<EllegiaUser>>();
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<EllegiaRole>>();

            var userName = configuration["Users:AdminUser:Name"];
            var email = configuration["Users:AdminUser:Email"];
            var password = configuration["Users:AdminUser:Password"];
            var role = configuration["Users:AdminUser:Role"];

            if (await userManager.FindByNameAsync(userName) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                    await roleManager.CreateAsync(new EllegiaRole { Name = role });

                var user = new EllegiaUser
                {
                    UserName = userName,
                    Email = email
                };

                var result = await userManager
                    .CreateAsync(user, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, role);
            }
        }

        public static void Seed(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<EllegiaContext>();
            
            context.EnsureSeeded(new[]
            {
                new ContactTypesSeeder()
            });
        }
    }
}