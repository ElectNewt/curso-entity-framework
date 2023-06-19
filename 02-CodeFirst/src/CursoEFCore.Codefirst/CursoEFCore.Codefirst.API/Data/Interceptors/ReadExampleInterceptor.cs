using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CursoEFCore.Codefirst.API.Data.Interceptors;

public class ReadExampleInterceptor : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        Console.WriteLine("======== HERE start Executing ==========");
        return base.ReaderExecuting(command, eventData, result);
    }
    
    public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {
        Console.WriteLine("======== HERE executed ==========");
        return base.ReaderExecuted(command, eventData, result);
    }
}