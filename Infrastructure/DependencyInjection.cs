using Application.Abstractions.DataAccess;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.MerchantContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AZURE_SQL_DATABASE");
        
        services.AddDbContext<MerchantDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IMerchantDbContext>(sp => sp.GetRequiredService<MerchantDbContext>());
        
        return services;
    }
}