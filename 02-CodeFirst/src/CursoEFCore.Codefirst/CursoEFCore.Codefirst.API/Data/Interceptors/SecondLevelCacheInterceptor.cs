using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;

namespace CursoEFCore.Codefirst.API.Data.Interceptors;

public class SecondLevelCacheInterceptor : DbCommandInterceptor
{
    private readonly IMemoryCache _cache;

    public SecondLevelCacheInterceptor(IMemoryCache cache)
    {
        _cache = cache;
    }

    public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command,
        CommandEventData eventData, InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        string key = command.CommandText +
                     string.Join(",", command.Parameters.Cast<DbParameter>().Select(p => p.Value));
        
        if (_cache.TryGetValue(key, out List<Dictionary<string, object>>? cacheEntry))
        {
            var table = new DataTable();
            if (cacheEntry != null && cacheEntry.Any())
            {
                foreach (var pair in cacheEntry.First())
                {
                    table.Columns.Add(pair.Key,
                        pair.Value is not null && pair.Value?.GetType() != typeof(DBNull)
                            ? pair.Value.GetType()
                            : typeof(object));
                }

                foreach (var row in cacheEntry)
                {
                    table.Rows.Add(row.Values.ToArray());
                }
            }

            var reader = table.CreateDataReader();
            Console.WriteLine("==== READ FROm CACHE ===");
            return InterceptionResult<DbDataReader>.SuppressWithResult(reader);
        }

        return result;
    }

    public override async ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command,
        CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
    {
        var key = command.CommandText + string.Join(",", command.Parameters.Cast<DbParameter>().Select(p => p.Value));


        var resultsList = new List<Dictionary<string, object>>();
        if (result.HasRows)
        {
            while (await result.ReadAsync())
            {
                var row = new Dictionary<string, object>();
                for (var i = 0; i < result.FieldCount; i++)
                {
                    row.TryAdd(result.GetName(i), result.GetValue(i));
                }

                resultsList.Add(row);
            }

            if (resultsList.Any())
            {
                _cache.Set(key, resultsList);
            }
        }

        result.Close();
        
        var table = new DataTable();
        if (resultsList.Any())
        {
        
            foreach (var pair in resultsList.First())
            {
                table.Columns.Add(pair.Key,
                    pair.Value is not null && pair.Value?.GetType() != typeof(DBNull)
                        ? pair.Value.GetType()
                        : typeof(object));
            }

            foreach (var row in resultsList)
            {
                table.Rows.Add(row.Values.ToArray());
            }
        }

        return table.CreateDataReader();
    }
}