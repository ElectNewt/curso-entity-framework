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
        => await _context.SaveChangesAsync();

    public void Dispose()
    {
        _context.Dispose();
    }
}