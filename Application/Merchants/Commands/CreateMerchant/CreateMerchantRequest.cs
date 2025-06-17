using Domain.Entities;

namespace Application.Merchants.Commands.CreateMerchant;

public sealed record CreateMerchantRequest(string Name, string Email, Guid CategoryId);