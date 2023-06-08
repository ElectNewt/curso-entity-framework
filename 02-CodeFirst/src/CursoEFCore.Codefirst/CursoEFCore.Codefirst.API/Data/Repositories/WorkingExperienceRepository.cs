using CursoEFCore.Codefirst.API.Data.Entities;

namespace CursoEFCore.Codefirst.API.Data.Repositories;

public interface IWorkingExperienceRepository
{
    Task Insert(List<Wokringexperience> workingExperiences);
}

public class WorkingExperienceRepository : IWorkingExperienceRepository
{
    private readonly CursoEfContext _context;

    public WorkingExperienceRepository(CursoEfContext cursoEfContext)
    {
        _context = cursoEfContext;
    }

    public async Task Insert(List<Wokringexperience> workingExperiences)
        => await _context.Wokringexperiences.AddRangeAsync(workingExperiences);

}