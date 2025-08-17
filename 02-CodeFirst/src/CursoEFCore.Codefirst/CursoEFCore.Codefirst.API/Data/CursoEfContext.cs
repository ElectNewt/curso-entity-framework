using CursoEFCore.Codefirst.API.Data.Entities;
using CursoEFCore.Codefirst.API.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        modelBuilder.Entity<Wokringexperience>()
            .HasQueryFilter(a => !a.IsDeleted);
        
        
        modelBuilder.Entity<User>()
            .OwnsOne<Address>(user=>user.Address)
            .ToJson();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((ctx, _) =>
        {
            if (!ctx.Set<User>().Any())
            {
                ctx.Set<User>().AddRange(UserSeed.BuildUsers());
                ctx.SaveChanges();
            }
        });
        
        base.OnConfiguring(optionsBuilder);
        
        
    }
}