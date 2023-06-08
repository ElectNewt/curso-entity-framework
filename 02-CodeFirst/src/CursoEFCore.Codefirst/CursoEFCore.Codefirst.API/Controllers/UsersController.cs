using CursoEFCore.Codefirst.API.Data.Entities;
using CursoEFCore.Codefirst.API.Data.Repositories;
using CursoEFCore.Codefirst.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursoEFCore.Codefirst.API.Controllers;

[Route("[controller]")]
public class UsersController : Controller
{
    private readonly UpdateUserEmail _updateUserEmail;
    private readonly InsertUser _insertUser;
    private readonly IUnitOfWork _unitOfWork;

    public UsersController(UpdateUserEmail updateUserEmail, IUnitOfWork unitOfWork, InsertUser insertUser)
    {
        _updateUserEmail = updateUserEmail;
        _unitOfWork = unitOfWork;
        _insertUser = insertUser;
    }
    

    [HttpGet]
    public async Task<List<User>> GetAll()
        => await _unitOfWork.UserRepository.GetAll();
    
    [HttpGet("{userId}")]
    public async Task<User?> GetById(int userId)
        => await _unitOfWork.UserRepository.GetById(userId);

    [HttpPost]
    public async Task<User> Create(int uniqueId)
        => await _insertUser.Execute(uniqueId);
    
    [HttpPut("update-email/{id}")]
    public async Task<bool> UpdateEmail(int id, string newEmail)
        => await _updateUserEmail.Execute(id, newEmail);

    [HttpDelete("{userId}")]
    public async Task<bool> Delete(int userId)
    {
        bool result = await _unitOfWork.UserRepository.Delete(userId);
        await _unitOfWork.Save();
        return result;
    }
}