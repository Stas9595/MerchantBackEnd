namespace Domain.Abstractions;

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset Created { get; set; }
    
}