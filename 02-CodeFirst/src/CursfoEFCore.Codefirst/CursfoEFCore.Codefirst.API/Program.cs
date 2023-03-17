using CursfoEFCore.Codefirst.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CursoEfContext>();
    
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    CursoEfContext context = scope.ServiceProvider.GetRequiredService<CursoEfContext>();
    context.Database.Migrate();
}



app.MapGet("/", () => "Hello World!");


app.UseSwagger();
app.UseSwaggerUI();

app.Run();