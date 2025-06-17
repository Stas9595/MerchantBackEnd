using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations;

internal sealed class CategoryItemConfiguration: IEntityTypeConfiguration<Domain.Entities.Category>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Category> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.HasData(
            new Domain.Entities.Category { Id = Guid.NewGuid(), Name = "Retail" },
            new Domain.Entities.Category { Id = Guid.NewGuid(), Name = "Food" },
            new Domain.Entities.Category { Id = Guid.NewGuid(), Name = "Services" }
        );
    }
}
