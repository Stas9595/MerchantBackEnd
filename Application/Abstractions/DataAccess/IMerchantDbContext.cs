using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.DataAccess;

public interface IMerchantDbContext
{
    DbSet<Merchant> Merchants { get; }
    
    DbSet<Category> Categories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}