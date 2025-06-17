namespace Application.DTOs;

public record MerchantDto(
    Guid Id,
    string Name,
    string Email,
    string Category
);
