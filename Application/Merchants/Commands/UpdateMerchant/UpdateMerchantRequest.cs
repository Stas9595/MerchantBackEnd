namespace Application.Merchants.Commands.UpdateMerchant;

public sealed record UpdateMerchantRequest(string Name, string Email, Guid CategoryId);
