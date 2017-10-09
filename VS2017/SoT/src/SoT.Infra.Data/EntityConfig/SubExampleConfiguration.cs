using SoT.Domain.Entities.Example;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class SubExampleConfiguration : EntityTypeConfiguration<SubExample>
    {
        public SubExampleConfiguration()
        {
            // For more information google Fluent API

            HasKey(s => s.SubExampleId);

            Property(s => s.StringPropertyName)
                .HasMaxLength(150)
                .IsRequired();

            Property(s => s.DatePropertyName)
                .IsRequired();

            // boolean values are required by nature
            Property(s => s.Active)
                .IsRequired();

            Property(s => s.RegisterDate)
                .IsRequired();

            Ignore(s => s.CalculatedPropertyName);

            HasRequired(s => s.Example)
                .WithMany()
                .HasForeignKey(s => s.ExampleId);
        }
    }
}
