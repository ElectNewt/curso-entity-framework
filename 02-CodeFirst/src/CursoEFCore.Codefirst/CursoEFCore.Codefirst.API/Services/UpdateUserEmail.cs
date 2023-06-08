using CursoEFCore.Codefirst.API.Data.Entities;
using CursoEFCore.Codefirst.API.Data.Repositories;

namespace CursoEFCore.Codefirst.API.Services;

public class UpdateUserEmail
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserEmail(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Execute(int userId, string newEmail)
    {
        User? user = await _unitOfWork.UserRepository.GetById(userId);
        if (user != null)
        {
            user.Email = newEmail;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Save();
        }

        return true;
    }
}