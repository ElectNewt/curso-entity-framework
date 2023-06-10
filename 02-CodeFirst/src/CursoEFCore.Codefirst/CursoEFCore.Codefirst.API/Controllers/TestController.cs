using CursoEFCore.Codefirst.API.Data;
using CursoEFCore.Codefirst.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Codefirst.API.Controllers;

[Route("[controller]")]
public class TestController : Controller
{
    private readonly CursoEfContext _context;

    public TestController(CursoEfContext context)
    {
        _context = context;
    }

    [HttpGet("iqueryablepagination")]
    public async Task<List<User>> QueryablePaginationExample(int pageNumber, int pageSize, string emailFilter)
    {
        List<User> result = await _context.Users
            .Where(a => a.Email.Contains(emailFilter))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return result;
    }

    [HttpGet("iqueryablen1")]
    public async Task<bool> QueryableN1Example()
    {
        IQueryable<User> users = _context.Users;
        foreach (User user in users)
        {
            ICollection<Wokringexperience> experiences = user.Wokringexperiences;
        }

        return true;
    }
}