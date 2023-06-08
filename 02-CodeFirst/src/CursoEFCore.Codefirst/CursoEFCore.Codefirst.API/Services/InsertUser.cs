using CursoEFCore.Codefirst.API.Data.Entities;
using CursoEFCore.Codefirst.API.Data.Repositories;

namespace CursoEFCore.Codefirst.API.Services;

public class InsertUser
{
    private readonly IUnitOfWork _unitOfWork;

    public InsertUser(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User> Execute(int id)
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
        
        user = await _unitOfWork.UserRepository.Insert(user);
        await _unitOfWork.WorkingExperienceRepository.Insert(workingExperiences);
        _ = await _unitOfWork.Save();
        
        return user;
    }
}