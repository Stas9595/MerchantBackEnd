using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.MerchantContext;

public sealed class MerchantDbContext(DbContextOptions options)
    : DbContext(options), IMerchantDbContext
{
    public DbSet<Merchant> Merchants { get; set; }
    
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MerchantDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        var utcNow = DateTime.UtcNow;
        
        var addedOrUpdatedEntries = ChangeTracker.Entries()
            .Where(x => x.State is EntityState.Added or EntityState.Modified).ToList();

        foreach (var entry in addedOrUpdatedEntries)
        {
            if (entry.Entity is not AuditableEntity entity)
            {
                continue;
            }

            switch (entry.State)
            {
                case EntityState.Added:
                    entity.Created = utcNow;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}