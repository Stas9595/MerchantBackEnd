using Application.Abstractions.DataAccess;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Queries.GetCategories;

public class GetCategoriesHandler(IMerchantDbContext merchantDbContext) 
    : IQueryHandler<GetCategoriesQuery, List<Category>>
{
    public async Task<List<Category>> Handle(GetCategoriesQuery? request, CancellationToken cancellationToken)
    {
        return await merchantDbContext.Categories.OrderBy(c => c.Name).ToListAsync(cancellationToken);
    }
}