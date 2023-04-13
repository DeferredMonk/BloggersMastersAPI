using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloggersMastersAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublicPost = table.Column<bool>(type: "bit", nullable: false),
                    Agrees = table.Column<int>(type: "int", nullable: false),
                    Disagrees = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "firstName", "lastName", "username" },
                values: new object[,]
                {
                    { 1, "Will", "Smith", "WillSmith" },
                    { 2, "Peter", "Griffin", "PeterGriffin" },
                    { 3, "Homer", "Simpsons", "HomeSimpsons" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Agrees", "Content", "CreatedAt", "Disagrees", "ModifiedAt", "PublicPost", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 0, "One of my greatest achiements is winning a league game!", new DateTime(2023, 4, 13, 18, 10, 8, 439, DateTimeKind.Local).AddTicks(6344), 0, null, false, "My greatest achievements", 1 },
                    { 2, 0, "I've currently spent a month looking for a job as a web dev. Lets hope this is the one.", new DateTime(2023, 4, 13, 18, 10, 8, 439, DateTimeKind.Local).AddTicks(6394), 0, null, true, "Job hunting", 1 },
                    { 3, 0, "Today I printed hello world to my console, I felt like a hacker!", new DateTime(2023, 4, 13, 18, 10, 8, 439, DateTimeKind.Local).AddTicks(6396), 0, null, true, "Hello world!", 2 },
                    { 4, 0, "Finally I master the skills of C#, its time to apply for amazing opportunities!", new DateTime(2023, 4, 13, 18, 10, 8, 439, DateTimeKind.Local).AddTicks(6398), 0, null, true, "I just finished Noroff's bootcamp!", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
