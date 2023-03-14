using CursfoEFCore.Codefirst.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursfoEFCore.Codefirst.API.Data;

public class CursoEfContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wokringexperience> Wokringexperiences { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;port=4306;database=cursoEF;user=root;password=cursoEFpass");
}