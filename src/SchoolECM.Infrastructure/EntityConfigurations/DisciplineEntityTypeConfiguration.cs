using eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

namespace eShop.Ordering.Infrastructure.EntityConfigurations;

class DisciplineEntityTypeConfiguration
    : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> disciplineConfiguration)
    {
        disciplineConfiguration.Property(o => o.Id)
            .UseHiLo("disciplineseq");/*

        disciplineConfiguration.Property<int>("DisciplineId");*/
    }
}
