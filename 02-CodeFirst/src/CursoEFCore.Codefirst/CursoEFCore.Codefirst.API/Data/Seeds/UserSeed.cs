﻿using CursoEFCore.Codefirst.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Codefirst.API.Data.Seeds;

public class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User { Email = "example1@mail.com", Id = 1, UserName = "user1" },
            new User { Email = "user2@mail.com", Id = 2, UserName = "user2" }
        );
    }
}