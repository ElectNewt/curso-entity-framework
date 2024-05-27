using CursoEFCore.Codefirst.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CursoEFCore.Codefirst.API.Data.Repositories;

public interface IGenericRepository<T, TId>
    where T : CursoEFBaseEntity<TId>
{
    Task<T> Insert(T entity);
    Task<T?> GetById(TId id);
    IQueryable<T> GetAll();
    void Update(T entity);
    Task<bool> SoftDelete(TId id);
    Task<bool> HardDelete(TId id);
}

public abstract class GenericRepository<T, TId> : IGenericRepository<T, TId>
    where T : CursoEFBaseEntity<TId>
    where TId : IEquatable<TId>
{
    private readonly CursoEfContext _context;
    protected DbSet<T> Entities => _context.Set<T>();

    protected GenericRepository(CursoEfContext context)
    {
        _context = context;
    }

    public async Task<T> Insert(T entity)
    {
        EntityEntry<T> insertedValue = await _context.Set<T>().AddAsync(entity);
        return insertedValue.Entity;
    }

    public virtual async Task<T?> GetById(TId id)
        => await _context.Set<T>()
            .FirstAsync(a=>a.Id.Equals(id));


    public IQueryable<T> GetAll()
        => _context.Set<T>();

    public void Update(T entity)
    {
        entity.LastUpdateUtc = DateTime.UtcNow;
        _context.Set<T>().Update(entity);
    }

    public async Task<bool> SoftDelete(TId id)
    {
        T? entity = await GetById(id);

        if (entity is null)
            return false;

        entity.IsDeleted = true;
        entity.DeletedTimeUtc = DateTime.UtcNow;

        _context.Set<T>().Update(entity);
        return true;
    }

    public async Task<bool> HardDelete(TId id)
    {
        T? entity = await GetById(id);
        if (entity is null)
            return false;
        _context.Set<T>().Remove(entity);
        return true;
    }
}