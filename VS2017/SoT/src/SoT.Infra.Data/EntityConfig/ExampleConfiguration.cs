using SoT.Domain.Entities.Example;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class ExampleConfiguration : EntityTypeConfiguration<Example>
    {
        public ExampleConfiguration()
        {
            // For more information google Fluent API

            HasKey(e => e.ExampleId);

            Property(e => e.Name)
                .HasMaxLength(250)
                .IsRequired();

            Property(e => e.DatePropertyName)
                .IsRequired();

            // boolean values are required by nature
            Property(e => e.Active)
                .IsRequired();

            Property(e => e.RegisterDate)
                .IsRequired();
        }
    }
}
