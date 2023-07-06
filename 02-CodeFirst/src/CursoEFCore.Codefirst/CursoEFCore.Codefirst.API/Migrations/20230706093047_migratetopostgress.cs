using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CursoEFCore.Codefirst.API.Migrations
{
    /// <inheritdoc />
    public partial class migratetopostgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wokringexperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    Environment = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wokringexperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wokringexperiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedTimeUtc", "Email", "IsDeleted", "UserName" },
                values: new object[,]
                {
                    { 1, null, "example1@mail.com", false, "user1" },
                    { 2, null, "example2@mail.com", false, "user2" },
                    { 3, null, "example3@mail.com", false, "user3" },
                    { 4, null, "example4@mail.com", false, "user4" },
                    { 5, null, "example5@mail.com", false, "user5" },
                    { 6, null, "example6@mail.com", false, "user6" },
                    { 7, null, "example7@mail.com", false, "user7" },
                    { 8, null, "example8@mail.com", false, "user8" },
                    { 9, null, "example9@mail.com", false, "user9" },
                    { 10, null, "example10@mail.com", false, "user10" },
                    { 11, null, "example11@mail.com", false, "user11" },
                    { 12, null, "example12@mail.com", false, "user12" },
                    { 13, null, "example13@mail.com", false, "user13" },
                    { 14, null, "example14@mail.com", false, "user14" },
                    { 15, null, "example15@mail.com", false, "user15" },
                    { 16, null, "example16@mail.com", false, "user16" },
                    { 17, null, "example17@mail.com", false, "user17" },
                    { 18, null, "example18@mail.com", false, "user18" },
                    { 19, null, "example19@mail.com", false, "user19" },
                    { 20, null, "example20@mail.com", false, "user20" },
                    { 21, null, "example21@mail.com", false, "user21" },
                    { 22, null, "example22@mail.com", false, "user22" },
                    { 23, null, "example23@mail.com", false, "user23" },
                    { 24, null, "example24@mail.com", false, "user24" },
                    { 25, null, "example25@mail.com", false, "user25" },
                    { 26, null, "example26@mail.com", false, "user26" },
                    { 27, null, "example27@mail.com", false, "user27" },
                    { 28, null, "example28@mail.com", false, "user28" },
                    { 29, null, "example29@mail.com", false, "user29" },
                    { 30, null, "example30@mail.com", false, "user30" },
                    { 31, null, "example31@mail.com", false, "user31" },
                    { 32, null, "example32@mail.com", false, "user32" },
                    { 33, null, "example33@mail.com", false, "user33" },
                    { 34, null, "example34@mail.com", false, "user34" },
                    { 35, null, "example35@mail.com", false, "user35" },
                    { 36, null, "example36@mail.com", false, "user36" },
                    { 37, null, "example37@mail.com", false, "user37" },
                    { 38, null, "example38@mail.com", false, "user38" },
                    { 39, null, "example39@mail.com", false, "user39" },
                    { 40, null, "example40@mail.com", false, "user40" },
                    { 41, null, "example41@mail.com", false, "user41" },
                    { 42, null, "example42@mail.com", false, "user42" },
                    { 43, null, "example43@mail.com", false, "user43" },
                    { 44, null, "example44@mail.com", false, "user44" },
                    { 45, null, "example45@mail.com", false, "user45" },
                    { 46, null, "example46@mail.com", false, "user46" },
                    { 47, null, "example47@mail.com", false, "user47" },
                    { 48, null, "example48@mail.com", false, "user48" },
                    { 49, null, "example49@mail.com", false, "user49" },
                    { 50, null, "example50@mail.com", false, "user50" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wokringexperiences_UserId",
                table: "Wokringexperiences",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wokringexperiences");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
