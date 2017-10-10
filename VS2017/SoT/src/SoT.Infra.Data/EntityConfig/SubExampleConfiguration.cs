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

            Property(s => s.SubExampleDatePropertyName)
                .IsRequired();

            Ignore(s => s.CalculatedPropertyName);

            HasRequired(s => s.Example)
                .WithMany()
                .HasForeignKey(s => s.ExampleId);
        }
    }
}
