﻿// <auto-generated />
using System;
using CursoEFCore.Codefirst.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoEFCore.Codefirst.API.Migrations
{
    [DbContext(typeof(CursoEfContext))]
    partial class CursoEfContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CursoEFCore.Codefirst.API.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedTimeUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "example1@mail.com",
                            IsDeleted = false,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "example2@mail.com",
                            IsDeleted = false,
                            UserName = "user2"
                        },
                        new
                        {
                            Id = 3,
                            Email = "example3@mail.com",
                            IsDeleted = false,
                            UserName = "user3"
                        },
                        new
                        {
                            Id = 4,
                            Email = "example4@mail.com",
                            IsDeleted = false,
                            UserName = "user4"
                        },
                        new
                        {
                            Id = 5,
                            Email = "example5@mail.com",
                            IsDeleted = false,
                            UserName = "user5"
                        },
                        new
                        {
                            Id = 6,
                            Email = "example6@mail.com",
                            IsDeleted = false,
                            UserName = "user6"
                        },
                        new
                        {
                            Id = 7,
                            Email = "example7@mail.com",
                            IsDeleted = false,
                            UserName = "user7"
                        },
                        new
                        {
                            Id = 8,
                            Email = "example8@mail.com",
                            IsDeleted = false,
                            UserName = "user8"
                        },
                        new
                        {
                            Id = 9,
                            Email = "example9@mail.com",
                            IsDeleted = false,
                            UserName = "user9"
                        },
                        new
                        {
                            Id = 10,
                            Email = "example10@mail.com",
                            IsDeleted = false,
                            UserName = "user10"
                        },
                        new
                        {
                            Id = 11,
                            Email = "example11@mail.com",
                            IsDeleted = false,
                            UserName = "user11"
                        },
                        new
                        {
                            Id = 12,
                            Email = "example12@mail.com",
                            IsDeleted = false,
                            UserName = "user12"
                        },
                        new
                        {
                            Id = 13,
                            Email = "example13@mail.com",
                            IsDeleted = false,
                            UserName = "user13"
                        },
                        new
                        {
                            Id = 14,
                            Email = "example14@mail.com",
                            IsDeleted = false,
                            UserName = "user14"
                        },
                        new
                        {
                            Id = 15,
                            Email = "example15@mail.com",
                            IsDeleted = false,
                            UserName = "user15"
                        },
                        new
                        {
                            Id = 16,
                            Email = "example16@mail.com",
                            IsDeleted = false,
                            UserName = "user16"
                        },
                        new
                        {
                            Id = 17,
                            Email = "example17@mail.com",
                            IsDeleted = false,
                            UserName = "user17"
                        },
                        new
                        {
                            Id = 18,
                            Email = "example18@mail.com",
                            IsDeleted = false,
                            UserName = "user18"
                        },
                        new
                        {
                            Id = 19,
                            Email = "example19@mail.com",
                            IsDeleted = false,
                            UserName = "user19"
                        },
                        new
                        {
                            Id = 20,
                            Email = "example20@mail.com",
                            IsDeleted = false,
                            UserName = "user20"
                        },
                        new
                        {
                            Id = 21,
                            Email = "example21@mail.com",
                            IsDeleted = false,
                            UserName = "user21"
                        },
                        new
                        {
                            Id = 22,
                            Email = "example22@mail.com",
                            IsDeleted = false,
                            UserName = "user22"
                        },
                        new
                        {
                            Id = 23,
                            Email = "example23@mail.com",
                            IsDeleted = false,
                            UserName = "user23"
                        },
                        new
                        {
                            Id = 24,
                            Email = "example24@mail.com",
                            IsDeleted = false,
                            UserName = "user24"
                        },
                        new
                        {
                            Id = 25,
                            Email = "example25@mail.com",
                            IsDeleted = false,
                            UserName = "user25"
                        },
                        new
                        {
                            Id = 26,
                            Email = "example26@mail.com",
                            IsDeleted = false,
                            UserName = "user26"
                        },
                        new
                        {
                            Id = 27,
                            Email = "example27@mail.com",
                            IsDeleted = false,
                            UserName = "user27"
                        },
                        new
                        {
                            Id = 28,
                            Email = "example28@mail.com",
                            IsDeleted = false,
                            UserName = "user28"
                        },
                        new
                        {
                            Id = 29,
                            Email = "example29@mail.com",
                            IsDeleted = false,
                            UserName = "user29"
                        },
                        new
                        {
                            Id = 30,
                            Email = "example30@mail.com",
                            IsDeleted = false,
                            UserName = "user30"
                        },
                        new
                        {
                            Id = 31,
                            Email = "example31@mail.com",
                            IsDeleted = false,
                            UserName = "user31"
                        },
                        new
                        {
                            Id = 32,
                            Email = "example32@mail.com",
                            IsDeleted = false,
                            UserName = "user32"
                        },
                        new
                        {
                            Id = 33,
                            Email = "example33@mail.com",
                            IsDeleted = false,
                            UserName = "user33"
                        },
                        new
                        {
                            Id = 34,
                            Email = "example34@mail.com",
                            IsDeleted = false,
                            UserName = "user34"
                        },
                        new
                        {
                            Id = 35,
                            Email = "example35@mail.com",
                            IsDeleted = false,
                            UserName = "user35"
                        },
                        new
                        {
                            Id = 36,
                            Email = "example36@mail.com",
                            IsDeleted = false,
                            UserName = "user36"
                        },
                        new
                        {
                            Id = 37,
                            Email = "example37@mail.com",
                            IsDeleted = false,
                            UserName = "user37"
                        },
                        new
                        {
                            Id = 38,
                            Email = "example38@mail.com",
                            IsDeleted = false,
                            UserName = "user38"
                        },
                        new
                        {
                            Id = 39,
                            Email = "example39@mail.com",
                            IsDeleted = false,
                            UserName = "user39"
                        },
                        new
                        {
                            Id = 40,
                            Email = "example40@mail.com",
                            IsDeleted = false,
                            UserName = "user40"
                        },
                        new
                        {
                            Id = 41,
                            Email = "example41@mail.com",
                            IsDeleted = false,
                            UserName = "user41"
                        },
                        new
                        {
                            Id = 42,
                            Email = "example42@mail.com",
                            IsDeleted = false,
                            UserName = "user42"
                        },
                        new
                        {
                            Id = 43,
                            Email = "example43@mail.com",
                            IsDeleted = false,
                            UserName = "user43"
                        },
                        new
                        {
                            Id = 44,
                            Email = "example44@mail.com",
                            IsDeleted = false,
                            UserName = "user44"
                        },
                        new
                        {
                            Id = 45,
                            Email = "example45@mail.com",
                            IsDeleted = false,
                            UserName = "user45"
                        },
                        new
                        {
                            Id = 46,
                            Email = "example46@mail.com",
                            IsDeleted = false,
                            UserName = "user46"
                        },
                        new
                        {
                            Id = 47,
                            Email = "example47@mail.com",
                            IsDeleted = false,
                            UserName = "user47"
                        },
                        new
                        {
                            Id = 48,
                            Email = "example48@mail.com",
                            IsDeleted = false,
                            UserName = "user48"
                        },
                        new
                        {
                            Id = 49,
                            Email = "example49@mail.com",
                            IsDeleted = false,
                            UserName = "user49"
                        },
                        new
                        {
                            Id = 50,
                            Email = "example50@mail.com",
                            IsDeleted = false,
                            UserName = "user50"
                        });
                });

            modelBuilder.Entity("CursoEFCore.Codefirst.API.Data.Entities.Wokringexperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedTimeUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Environment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Wokringexperiences");
                });

            modelBuilder.Entity("CursoEFCore.Codefirst.API.Data.Entities.Wokringexperience", b =>
                {
                    b.HasOne("CursoEFCore.Codefirst.API.Data.Entities.User", "User")
                        .WithMany("Wokringexperiences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CursoEFCore.Codefirst.API.Data.Entities.User", b =>
                {
                    b.Navigation("Wokringexperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
