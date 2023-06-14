using CursoEFCore.Codefirst.API.Data;
using CursoEFCore.Codefirst.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Codefirst.API.Controllers;

//Example controller for load data post
[ApiController]
[Route("[controller]")]
public class LoadDataPostController : Controller
{
    private readonly CursoEfContext _context;

    public LoadDataPostController(CursoEfContext context)
    {
        _context = context;
    }

    [HttpGet("eager-loading")]
    public async Task<List<User>> EagerLoading()
        => await _context.Users
            .Include(a => a.Wokringexperiences)
            .ToListAsync();

    [HttpGet("lazy-loading/{userId}")]
    public async Task<User?> LazyLoading(int userId)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(a => a.Id == userId);

        if (user is not null)
        {
            var experiences = user.Wokringexperiences;
            if (experiences is not null && experiences.Any())
            {
                Console.WriteLine("this user has experiences");
            }
        }

        return user;
    }

    [HttpGet("explicit-loading/{userId}")]
    public async Task<User?> ExplicitLoading(int userId)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(a => a.Id == userId);

        if (user is not null)
        {
            await _context.Entry(user)
                .Collection(a => a.Wokringexperiences)
                .LoadAsync();

            if (user.Wokringexperiences is not null && user.Wokringexperiences.Any())
            {
                Console.WriteLine("this user has experiences");
            }
        }

        return user;
    }

    [HttpGet("raw-sql/{userId}")]
    public async Task<User?> RawSql(int userId)
    {
        return await _context.Users
            .FromSqlInterpolated($"Select * from Users where id = {userId}")
            .FirstAsync();
    }
}