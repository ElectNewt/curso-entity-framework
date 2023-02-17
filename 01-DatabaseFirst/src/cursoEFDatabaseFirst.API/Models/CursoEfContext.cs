using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cursoEFDatabaseFirst.API.Models;

public partial class CursoEfContext : DbContext
{
    public CursoEfContext()
    {
    }

    public CursoEfContext(DbContextOptions<CursoEfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Userid> Userids { get; set; }

    public virtual DbSet<Wokringexperience> Wokringexperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;port=4306;database=cursoEF;user=root;password=cursoEFpass");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Userid>(entity =>
        {
            entity.HasKey(e => e.UserId1).HasName("PRIMARY");

            entity.ToTable("userid");

            entity.HasIndex(e => e.UserName, "UserName").IsUnique();

            entity.Property(e => e.UserId1)
                .HasColumnType("int(11)")
                .HasColumnName("UserId");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<Wokringexperience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("wokringexperience");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Details).HasMaxLength(5000);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Environment).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.Wokringexperiences)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("wokringexperience_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
