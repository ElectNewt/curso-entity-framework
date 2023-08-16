using CursoEFCore.Codefirst.API.Data;
using CursoEFCore.Codefirst.API.Data.Entities;
using CursoEFCore.Codefirst.API.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace CursoEFCore.Codefirst.Test.Services;

public class TestInsertUserDbContext
{
    [Fact]
    public async Task WhenUsernameDoesNotExist_ThenUserInserted()
    {
        CursoEfContext context = Substitute.For<CursoEfContext>(new DbContextOptions<CursoEfContext>());


        DbSet<User> userDbSet = FakeDbSet(new List<User>());
        context.Users.Returns(userDbSet);

        DbSet<Wokringexperience> dbSetWorkingExperiences = FakeDbSet(new List<Wokringexperience>());
        context.Wokringexperiences.Returns(dbSetWorkingExperiences);

        InsertUserDbContext subject = new InsertUserDbContext(context);

        var result = await subject.Execute(10);

        Assert.True(result);
    }

    [Fact]
    public async Task WhenUsernameDoesExist_ThenNotInserted()
    {
        int id = 1;
        CursoEfContext context = Substitute.For<CursoEfContext>(new DbContextOptions<CursoEfContext>());


        DbSet<User> userDbSet = FakeDbSet(new List<User>() { new User() { UserName = $"id{id}" } });
        context.Users.Returns(userDbSet);

        InsertUserDbContext subject = new InsertUserDbContext(context);

        var result = await subject.Execute(id);

        Assert.False(result);
    }

    private static DbSet<T> FakeDbSet<T>(List<T> data) where T : class
    {
        var _data = data.AsQueryable();
        var fakeDbSet = Substitute.For<DbSet<T>, IQueryable<T>>();
        ((IQueryable<T>)fakeDbSet).Provider.Returns(_data.Provider);
        ((IQueryable<T>)fakeDbSet).Expression.Returns(_data.Expression);
        ((IQueryable<T>)fakeDbSet).ElementType.Returns(_data.ElementType);
        ((IQueryable<T>)fakeDbSet).GetEnumerator().Returns(_data.GetEnumerator());

        fakeDbSet.AsQueryable().Returns(fakeDbSet);

        return fakeDbSet;
    }

    [Fact]
    public async Task WhenUsernameDoesNotExist_ThenUserInsertedInDatabase()
    {
        CursoEfContext context = GetInMemoryDbContext();
        InsertUserDbContext subject = new InsertUserDbContext(context);

        var result = await subject.Execute(10);

        Assert.True(result);
    }
    
    [Fact]
    public async Task WhenUsernameDoesExist_ThenNotInsertedInDatabase() //inMemory
    {
        int id = 1;
        CursoEfContext context = GetInMemoryDbContext();
        await context.Users.AddAsync(new User() { UserName = $"id{id}", Email = "mail@mail.com"});
        await context.SaveChangesAsync();

        InsertUserDbContext subject = new InsertUserDbContext(context);
        var result = await subject.Execute(id);

        Assert.False(result);
    }

    private CursoEfContext GetInMemoryDbContext()
    {
        DbContextOptions<CursoEfContext> databaseOptions = new DbContextOptionsBuilder<CursoEfContext>()
            .UseInMemoryDatabase("CursoDatabase")
            .Options;
        
        return new CursoEfContext(databaseOptions);
    }
    
    
    
}