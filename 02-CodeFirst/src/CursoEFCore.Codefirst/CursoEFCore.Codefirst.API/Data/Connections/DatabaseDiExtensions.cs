using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Codefirst.API.Data.Connections;

public static class DatabaseDiExtensions
{
    public static void AddMySql(this IServiceCollection services)
    {
        services.AddDbContext<CursoEfContext>(options=>
            options
            .UseLazyLoadingProxies()
            .UseMySQL("server=127.0.0.1;port=4306;database=cursoEF;user=root;password=cursoEFpass"));
    }
    
    public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoEfContext>(options=>
            options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection")));
    }
    
    public static void AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoEfContext>(options=>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));
    }
    
    public static void AddSqLite(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoEfContext>(options=>
            options.UseSqlite(configuration.GetConnectionString("SqLiteConnection")));
    }
    
    public static void AddCosmos(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoEfContext>(options=>
            options.UseCosmos(configuration.GetConnectionString("AzureCosmosConnection")!, "dbName"));
    }
    
    public static void AddOracle(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoEfContext>(options=>
            options.UseOracle(configuration.GetConnectionString("OracleConnection")));
    }
}