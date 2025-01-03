using eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

namespace eShop.Ordering.Infrastructure.EntityConfigurations;

class StudentEntityTypeConfiguration
    : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> studentConfiguration)
    {
        studentConfiguration.Property(b => b.Id)
            .UseHiLo("studentseq");
    }
}
