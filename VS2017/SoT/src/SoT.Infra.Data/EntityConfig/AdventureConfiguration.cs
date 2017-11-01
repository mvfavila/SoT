using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class AdventureConfiguration : EntityTypeConfiguration<Adventure>
    {
        public AdventureConfiguration()
        {
            HasKey(a => a.AdventureId);

            Property(a => a.Name)
                .HasMaxLength(250)
                .IsRequired();

            Property(a => a.Active)
                .IsRequired();

            HasRequired(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.CategoryId);

            HasRequired(a => a.City)
                .WithMany()
                .HasForeignKey(a => a.CityId);

            HasRequired(a => a.Address)
                .WithMany()
                .HasForeignKey(a => a.AddressId);

            Property(a => a.InsurenceMinimalAmount)
                .IsOptional()
                .HasPrecision(9, 2);

            HasRequired(a => a.Provider)
                .WithMany()
                .HasForeignKey(a => a.ProviderId);

            Ignore(a => a.ValidationResult);
        }
    }
}
