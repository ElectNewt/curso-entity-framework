using CursoEFCore.Codefirst.API.Data;
using CursoEFCore.Codefirst.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Codefirst.API.Controllers;

[ApiController]
//Example controller created to support the post about foreign Keys
[Route("[controller]")]
public class RelationsController : Controller
{
    private readonly CursoEfContext _context;


    public RelationsController(CursoEfContext context)
    {
        _context = context;
    }

    [HttpPost("InsertDataExample1")]
    public async Task InsertDataExample1()
    {
        User user1 = new User()
        {
            Email = $"{Guid.NewGuid()}@mail.com",
            UserName = "id1"
        };

        List<Wokringexperience> workingExperiences1 = new List<Wokringexperience>()
        {
            new Wokringexperience()
            {
                UserId = user1.Id,
                Name = "experience 1",
                Details = "details1",
                Environment = "environment"
            },
            new Wokringexperience()
            {
                UserId = user1.Id,
                Name = "experience 2",
                Details = "details2",
                Environment = "environment"
            }
        };

        await _context.Users.AddAsync(user1);
        await _context.Wokringexperiences.AddRangeAsync(workingExperiences1);
        await _context.SaveChangesAsync();
    }

    [HttpPost("InsertDataExample2")]
    public async Task InsertDataExample2()
    {
        User user1 = new User()
        {
            Email = $"{Guid.NewGuid()}@mail.com",
            UserName = "id1",
            Wokringexperiences = new List<Wokringexperience>()
            {
                new Wokringexperience()
                {
                    Name = "experience 1 same object",
                    Details = "details1",
                    Environment = "environment"
                },
                new Wokringexperience()
                {
                    Name = "experience 2 same object",
                    Details = "details2",
                    Environment = "environment"
                }
            }
        };


        await _context.Users.AddAsync(user1);
        await _context.SaveChangesAsync();
    }

    [HttpGet("{userId}")]
    public async Task<User?> GetExample(int userId)
        => await _context.Users
            .Include(u => u.Wokringexperiences)
            .FirstOrDefaultAsync(a => a.Id == userId);
}