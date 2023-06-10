using CursoEFCore.Codefirst.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Codefirst.API.Data.Seeds;

public class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(a => !a.IsDeleted);

        builder.HasData(
            BuildUsers()
        );
    }

    private List<User> BuildUsers()
    {
        List<User> users = new List<User>();
        foreach (int index in Enumerable.Range(1, 50))
        {
            users.Add(new User
                { Email = $"example{index}@mail.com", Id = index, UserName = $"user{index}", IsDeleted = false });
        }

        return users;
    }
}