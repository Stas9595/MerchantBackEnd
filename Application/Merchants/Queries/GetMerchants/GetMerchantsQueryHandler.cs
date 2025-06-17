using Application.Abstractions.DataAccess;
using Application.Abstractions.Messaging;
using Application.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Merchants.Queries.GetMerchants;

internal sealed class GetMerchantsQueryHandler(IMerchantDbContext merchantDbContext) 
    : IQueryHandler<GetMerchantsQuery, List<MerchantDto>>
{
    public async Task<List<MerchantDto>> Handle(GetMerchantsQuery? request, CancellationToken cancellationToken)
    {
        var query = merchantDbContext.Merchants
            .Include(m => m.Category)
            .AsQueryable();
            
        if (request is not null)
        {
            if (!string.IsNullOrWhiteSpace(request.Сategory))
            {
                query = query.Where(m => m.Category.Name.Contains(request.Сategory));
            }

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(m => m.Name.Contains(request.Name));
            }
        }
        return await query.Select(m => new MerchantDto(
            m.Id,
            m.Name,
            m.Email,
            m.Category.Name
        )).ToListAsync(cancellationToken);
    }
}