using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Codefirst.API.Data.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IWorkingExperienceRepository WorkingExperienceRepository { get; }
    Task<int> Save();
}

public class UnitOfWork : IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    public IWorkingExperienceRepository WorkingExperienceRepository { get; }
    private readonly CursoEfContext _context;

    public UnitOfWork(CursoEfContext context, IUserRepository userRepository, 
        IWorkingExperienceRepository workingExperienceRepository)
    {
        _context = context;
        UserRepository = userRepository;
        WorkingExperienceRepository = workingExperienceRepository;
    }

    public async Task<int> Save()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException concurrencyException)
        {
            Console.WriteLine("error de concurrencia");
            //Manejar la excepción del conflicto
        }
        return 0;
    }
 

    public void Dispose()
    {
        _context.Dispose();
    }
}