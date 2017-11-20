using SoT.Domain.Entities;
using SoT.Domain.Entities.Example;
using SoT.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace SoT.Infra.Data.Context
{
    /// <summary>
    /// Sum of This database context.
    /// </summary>
    public class SoTContext : BaseDbContext
    {
        /// <summary>
        /// Database context constructor.
        /// </summary>
        public SoTContext()
            : base("SumOfThisConnection")
        {

        }

        public DbSet<Example> Examples { get; set; }
        public DbSet<SubExample> SubExamples { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Custom configuration of the Entity Framework model creation.
        /// </summary>
        /// <param name="modelBuilder">See <see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(STANDARD_VARCHAR_COLUMN_MAX_SIZE));

            // Mappings
            modelBuilder.Configurations.Add(new ExampleConfiguration());
            modelBuilder.Configurations.Add(new SubExampleConfiguration());

            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new AdventureConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new ContinentConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new ElementConfiguration());
            modelBuilder.Configurations.Add(new ProviderConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Custom configuration added so all Date fields that represent the Date when the regiter<br/>
        /// was recorded in the Database receive a value and never be updated.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry =>
                entry.Entity.GetType().GetProperty(NAME_FOR_REGISTER_DATE_PROPERTY) != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property(NAME_FOR_REGISTER_DATE_PROPERTY).CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(NAME_FOR_REGISTER_DATE_PROPERTY).IsModified = false;
                }
            }

            return base.SaveChanges();
        }

        public System.Data.Entity.DbSet<SoT.Domain.Entities.Address> Addresses { get; set; }
    }
}
