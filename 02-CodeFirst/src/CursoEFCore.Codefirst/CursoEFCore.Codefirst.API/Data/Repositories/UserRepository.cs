using CursoEFCore.Codefirst.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CursoEFCore.Codefirst.API.Data.Repositories;

public interface IUserRepository
{
    Task<User> Insert(User user);
    Task<User?> GetById(int id);
}

public class UserRepository : IUserRepository
{
    private readonly CursoEfContext _context;

    public UserRepository(CursoEfContext context)
    {
        _context = context;
    }

    public async Task<User> Insert(User user)
    {
        EntityEntry<User> insertedUser = await _context.Users.AddAsync(user);
        return insertedUser.Entity;
    }

    public async Task<User?> GetById(int id)
        => await _context.Users
            .Include(a => a.Wokringexperiences)
            .FirstOrDefaultAsync(x => x.Id == id);
}