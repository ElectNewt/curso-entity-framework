using CursoEFCore.Codefirst.API.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CursoEFCore.Codefirst.API.Data.Connections;

public static class DatabaseDiExtensions
{
    public static void AddMySql(this IServiceCollection services)
    {
        services.AddScoped<IDbConnectionManager, DbConnectionManager>();
        
        services.AddDbContext<CursoEfContext>((serviceProvider, options) =>
            options
                .UseLazyLoadingProxies()
                .AddInterceptors(new ReadExampleInterceptor(),
                    new SecondLevelCacheInterceptor(serviceProvider.GetRequiredService<IMemoryCache>()))
                .UseMySQL(serviceProvider.GetRequiredService<IDbConnectionManager>().GetConnectionString()));
    }

    public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoEfContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection")));
    }

    public static void AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoEfContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));
    }

    public static void AddSqLite(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoEfContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("SqLiteConnection")));
    }

    public static void AddCosmos(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoEfContext>(options =>
            options.UseCosmos(configuration.GetConnectionString("AzureCosmosConnection")!, "dbName"));
    }

    public static void AddOracle(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoEfContext>(options =>
            options.UseOracle(configuration.GetConnectionString("OracleConnection")));
    }
}