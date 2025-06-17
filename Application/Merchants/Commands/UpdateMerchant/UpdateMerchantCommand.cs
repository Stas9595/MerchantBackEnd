using Application.Abstractions.Messaging;
using Domain.Entities;

namespace Application.Merchants.Commands.UpdateMerchant;

public sealed record UpdateMerchantCommand(Guid Id, string Name, string Email, Guid CategoryId) : ICommand<Merchant>;