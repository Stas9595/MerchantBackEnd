using Application.Abstractions.Messaging;
using Domain.Entities;

namespace Application.Merchants.Commands.CreateMerchant;

public sealed record CreateMerchantCommand(string Name, string Email, Guid CategoryId) : ICommand<Merchant>;