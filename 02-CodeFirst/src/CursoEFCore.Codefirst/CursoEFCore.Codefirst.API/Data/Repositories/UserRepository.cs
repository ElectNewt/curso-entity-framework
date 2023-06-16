using CursoEFCore.Codefirst.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Codefirst.API.Data.Repositories;

public interface IUserRepository : IGenericRepository<User, int>
{
    Task<User?> GetByIdWithWorkingExperiences(int id);
}


public class UserRepository :  GenericRepository<User, int>, IUserRepository
{
    public UserRepository(CursoEfContext context) : base(context)
    {
    }

    public async Task<User?> GetByIdWithWorkingExperiences(int id)
        => await Entities
            .Include(a => a.Wokringexperiences)
            .FirstOrDefaultAsync(x => x.Id == id);
}