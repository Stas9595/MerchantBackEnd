using Infrastructure.DataAccess;
using Infrastructure.DataAccess.MerchantContext;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using MerchantDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<MerchantDbContext>();

        dbContext.Database.Migrate();
    }
}