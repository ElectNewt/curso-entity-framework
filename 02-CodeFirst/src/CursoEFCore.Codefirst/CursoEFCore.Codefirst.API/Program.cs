using CursoEFCore.Codefirst.API.Data;
using CursoEFCore.Codefirst.API.Data.Connections;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMySql();
    
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