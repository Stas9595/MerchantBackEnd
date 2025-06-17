using Application.Abstractions.DataAccess;
using Application.Abstractions.Messaging;

namespace Application.Merchants.Commands.DeleteMerchant;

public class DeleteMerchantHandler : ICommandHandler<DeleteMerchantCommand, bool>
{
    private readonly IMerchantDbContext _context;

    public DeleteMerchantHandler(IMerchantDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
    {
        var merchant = await _context.Merchants.FindAsync([request.Id], cancellationToken);

        if (merchant is null)
            return false;

        _context.Merchants.Remove(merchant);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}