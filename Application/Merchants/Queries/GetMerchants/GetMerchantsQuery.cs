using Application.Abstractions.Messaging;
using Application.DTOs;
using Domain.Entities;

namespace Application.Merchants.Queries.GetMerchants;

public sealed record GetMerchantsQuery(string? Сategory, string? Name) : IQuery<List<MerchantDto>>;