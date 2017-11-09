using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(e => e.BirthDate)
                .IsRequired();

            HasRequired(c => c.Provider)
                .WithMany()
                .HasForeignKey(c => c.ProviderId);

            Ignore(e => e.ValidationResult);
        }
    }
}
