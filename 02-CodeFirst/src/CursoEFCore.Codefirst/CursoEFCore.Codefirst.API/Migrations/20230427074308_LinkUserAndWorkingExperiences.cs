using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEFCore.Codefirst.API.Migrations
{
    /// <inheritdoc />
    public partial class LinkUserAndWorkingExperiences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Wokringexperiences_UserId",
                table: "Wokringexperiences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wokringexperiences_Users_UserId",
                table: "Wokringexperiences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wokringexperiences_Users_UserId",
                table: "Wokringexperiences");

            migrationBuilder.DropIndex(
                name: "IX_Wokringexperiences_UserId",
                table: "Wokringexperiences");
        }
    }
}
