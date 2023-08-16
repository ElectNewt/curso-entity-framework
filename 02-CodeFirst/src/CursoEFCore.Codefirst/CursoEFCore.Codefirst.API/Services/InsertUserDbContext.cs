using CursoEFCore.Codefirst.API.Data;
using CursoEFCore.Codefirst.API.Data.Entities;

namespace CursoEFCore.Codefirst.API.Services;

//This class is used only to show how the tests with DBContext works
public class InsertUserDbContext
{
    private readonly CursoEfContext _context;

    public InsertUserDbContext(CursoEfContext context)
    {
        _context = context;
    }

    public async Task<bool> Execute(int id)
    {
        User user = new User()
        {
            Email = $"{Guid.NewGuid()}@mail.com",
            UserName = $"id{id}"
        };

        List<Wokringexperience> workingExperiences = new List<Wokringexperience>()
        {
            new Wokringexperience()
            {
                User = user,
                Name = $"experience1 user {id}",
                Details = "details1",
                Environment = "environment"
            },
            new Wokringexperience()
            {
                User = user,
                Name = $"experience user {id}",
                Details = "details2",
                Environment = "environment"
            }
        };

        if (_context.Users.Any(a => a.UserName == user.UserName))
            return false;
        

        _ = await _context.Users.AddAsync(user);
        await _context.Wokringexperiences.AddRangeAsync(workingExperiences);
        _ = await _context.SaveChangesAsync();

        return true;
    }
}