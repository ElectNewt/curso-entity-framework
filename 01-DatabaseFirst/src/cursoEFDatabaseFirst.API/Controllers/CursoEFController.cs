using cursoEFDatabaseFirst.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace cursoEFDatabaseFirst.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoEFController : ControllerBase
{
    private readonly CursoEfContext _context;

    public CursoEFController(CursoEfContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<int> AddUser(UserDto userDto)
    {
        Userid user = new Userid()
        {
            UserName = userDto.UserName
        };

        await _context.Userids.AddAsync(user);
        await _context.SaveChangesAsync();
        
        return user.UserId1;
    }
}

public record UserDto(string UserName);