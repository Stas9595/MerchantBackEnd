using Domain.Abstractions;

namespace Domain.Entities;

public class Category : AuditableEntity
{
    public string Name { get; set; } = null!;
}