using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.PostgresSql;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<PostgresDbContext>(options =>
            options.UseNpgsql(
                "User ID=test;Password=test;Server=localhost;Port=5432;Database=prototype; Integrated Security=true;Pooling=true;"));
        return services;
    }
}
