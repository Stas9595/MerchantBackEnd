using Application.Abstractions.DataAccess;
using Application.Abstractions.Messaging;
using Domain.Entities;

namespace Application.Merchants.Commands.CreateMerchant;

internal sealed class CreateMerchantCommandHandler(IMerchantDbContext merchantDbContext)
    : ICommandHandler<CreateMerchantCommand, Merchant>
{
    public async Task<Merchant> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
    {
        var merchant = new Merchant
        {
            Name = request.Name,
            Email = request.Email,
            CategoryId = request.CategoryId
        };
        
        await merchantDbContext.Merchants.AddAsync(merchant, cancellationToken);
        
        try
        {
            await merchantDbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating merchant", ex);
        } 
        
        return merchant;
    }
}