using CursoEFCore.Codefirst.API.Data.Entities;
using Google.Protobuf.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace CursoEFCore.Codefirst.API.Data.Seeds;

public class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(a => !a.IsDeleted);
    }

    public static List<User> BuildUsers()
    {
        List<User> users = new List<User>();
        foreach (int index in Enumerable.Range(1, 50))
        {
            users.Add(new User
                { Email = $"example{index}@mail.com", 
                    Id = index, 
                    UserName = $"user{index}", 
                    IsDeleted = false, 
                    Address =  new Address()
                    {
                        City = $"city - {index}",
                        Country = $"country_{index}",
                        Street = $"street_{index}",
                        PostalCode = $"postal_code{index}"
                    }
                });
        }

        return users;
    }
}