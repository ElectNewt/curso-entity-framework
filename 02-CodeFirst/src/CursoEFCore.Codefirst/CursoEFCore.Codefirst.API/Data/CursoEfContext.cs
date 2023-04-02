using CursoEFCore.Codefirst.API.Data.Entities;
using CursoEFCore.Codefirst.API.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Codefirst.API.Data;

public class CursoEfContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wokringexperience> Wokringexperiences { get; set; }

    public CursoEfContext(DbContextOptions<CursoEfContext> context) : base(context)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserSeed());
    }
}