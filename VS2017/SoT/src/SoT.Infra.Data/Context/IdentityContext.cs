using SoT.Domain.Entities;
using SoT.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace SoT.Infra.Data.Context
{
    /// <summary>
    /// Identity database context.
    /// </summary>
    public class IdentityContext : BaseDbContext
    {
        /// <summary>
        /// Database context constructor.
        /// </summary>
        public IdentityContext()
            : base("SumOfThisConnection")
        {

        }

        public DbSet<User> Users { get; set; }

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
            modelBuilder.Configurations.Add(new UserConfiguration());

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
                if (entry.State == EntityState.Added)
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
    }
}
