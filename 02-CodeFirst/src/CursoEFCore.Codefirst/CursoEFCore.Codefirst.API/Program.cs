using System.Text.Json.Serialization;
using CursoEFCore.Codefirst.API.Data;
using CursoEFCore.Codefirst.API.Data.Connections;
using CursoEFCore.Codefirst.API.Data.Repositories;
using CursoEFCore.Codefirst.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddMySql();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWorkingExperienceRepository, WorkingExperienceRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<InsertUser>();
builder.Services.AddScoped<UpdateUserEmail>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    CursoEfContext context = scope.ServiceProvider.GetRequiredService<CursoEfContext>();
    context.Database.Migrate();
}



app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();