using Application.Abstractions.Messaging;
using Domain.Entities;

namespace Application.Merchants.Commands.DeleteMerchant;

public sealed record DeleteMerchantCommand(Guid Id) : ICommand<bool>;
