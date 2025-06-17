using Application.Abstractions.DataAccess;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Merchants.Commands.UpdateMerchant;

internal sealed class UpdateMerchantCommandHandler(IMerchantDbContext merchantDbContext) 
    : IRequestHandler<UpdateMerchantCommand, Merchant>
{
    public async Task<Merchant> Handle(UpdateMerchantCommand request, CancellationToken cancellationToken)
    {
        var record = await merchantDbContext.Merchants.SingleOrDefaultAsync(o => 
            o.Id == request.Id, cancellationToken: cancellationToken);

        if (record is null)
        {
            return null;
        }
        
        record.Name = request.Name;
        record.Email = request.Email;
        record.CategoryId = request.CategoryId;
        
        await merchantDbContext.SaveChangesAsync(cancellationToken);
        
        return record;
    }
}