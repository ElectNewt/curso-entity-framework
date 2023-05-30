using CursoEFCore.Codefirst.API.Data;
using CursoEFCore.Codefirst.API.Data.Entities;
using CursoEFCore.Codefirst.API.Data.Repositories;
using CursoEFCore.Codefirst.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursoEFCore.Codefirst.API.Controllers;

[ApiController]
//Example controller created to support the post about foreign Keys
[Route("[controller]")]
public class RelationsController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly InsertUser _insertUser;


    public RelationsController(IUserRepository userRepository, InsertUser insertUser)
    {
        _userRepository = userRepository;
        _insertUser = insertUser;
    }

    [HttpPost("InsertDataExample/{id}")]
    public async Task InsertDataExample1(int id)
        => await _insertUser.Execute(id);

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

        await _userRepository.Insert(user1);
    }

    [HttpGet("{userId}")]
    public async Task<User?> GetExample(int userId)
        => await _userRepository.GetById(userId);
}