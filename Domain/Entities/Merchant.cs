using Domain.Abstractions;

namespace Domain.Entities;

public class Merchant : AuditableEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}