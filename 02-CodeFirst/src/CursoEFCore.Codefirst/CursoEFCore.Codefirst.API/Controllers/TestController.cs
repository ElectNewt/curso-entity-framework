using CursoEFCore.Codefirst.API.Data;
using CursoEFCore.Codefirst.API.Data.Entities;
using CursoEFCore.Codefirst.API.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Codefirst.API.Controllers;

[Route("[controller]")]
public class TestController : Controller
{
    private readonly CursoEfContext _context;
    private readonly IUnitOfWork _unitOfWork;


    public TestController(CursoEfContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
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


    [HttpGet("cache-level1/{userId}")]
    public async Task<User?> CacheLevel1(int userId)
    {
        User? user =await _context.Users.FirstOrDefaultAsync(a => a.Id == userId);
        
        User? cachedUser =await _context.Users.FirstOrDefaultAsync(a => a.Id == userId);
        return cachedUser;
    }
    
    [HttpPut("concurrency/update-email/{id}")]
    public async Task<bool> UpdateEmail(int id, string newEmail)
    {
        User? user = await _unitOfWork.UserRepository.GetById(id);
        if (user != null)
        {
            //Sleep 10 seconds to be able to test the concurrency issue
            Thread.Sleep(10000);
            user.Email = newEmail;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Save();
        }

        return true;
    }
}