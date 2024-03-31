namespace CursoEFCore.Codefirst.API.Data.Connections;

public interface IDbConnectionManager
{
    string GetConnectionString();
}

public class DbConnectionManager : IDbConnectionManager
{
    private readonly IHttpContextAccessor _contextAccessor;

    public DbConnectionManager(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string GetConnectionString()
    {
        //_contextAccessor.GetTenant();
        //Calcular la url de la base de datos por tenant
        return "server=127.0.0.1;port=4306;database=cursoEF;user=root;password=cursoEFpass";
    }
}