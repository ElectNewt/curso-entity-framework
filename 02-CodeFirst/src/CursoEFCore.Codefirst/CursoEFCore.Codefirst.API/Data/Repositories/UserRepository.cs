using CursoEFCore.Codefirst.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CursoEFCore.Codefirst.API.Data.Repositories;

public interface IUserRepository
{
    Task<User> Insert(User user);
    Task<User?> GetById(int id);
    Task<List<User>> GetAll();
    void Update(User user);
    Task<bool> Delete(int id);
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
        await _context.SaveChangesAsync();
        return insertedUser.Entity;
    }

    public async Task<User?> GetById(int id)
        => await _context.Users
            .Include(a => a.Wokringexperiences)
            .FirstOrDefaultAsync(x => x.Id == id);

    public void Update(User user)
    {
        _context.Users.Update(user);
    }


    public async Task<List<User>> GetAll()
        => await _context.Users.ToListAsync();

    public async Task<bool> Delete(int id)
    {
        User? user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
            return false;

        user.IsDeleted = true;
        user.DeletedTimeUtc = DateTime.UtcNow;

        _context.Users.Update(user);
        return true;
    }

    public async Task<List<User>> GovernmentUsers()
        => await _context.Users
            .Include(a => a.Wokringexperiences
                .Where(we => we.Name == "Government"))
            .ToListAsync();
}