using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.DataAccess.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public AuditableEntityInterceptor()
    {
        
    }
}