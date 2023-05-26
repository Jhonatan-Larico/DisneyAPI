using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Disney.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    Story = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesOrSerie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesOrSerie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesOrSerie_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieOrSerieCharacter",
                columns: table => new
                {
                    CharactersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviesOrSeriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieOrSerieCharacter", x => new { x.CharactersId, x.MoviesOrSeriesId });
                    table.ForeignKey(
                        name: "FK_MovieOrSerieCharacter_Character_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieOrSerieCharacter_MoviesOrSerie_MoviesOrSeriesId",
                        column: x => x.MoviesOrSeriesId,
                        principalTable: "MoviesOrSerie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Age", "ImageUrl", "Name", "Story", "Weight" },
                values: new object[,]
                {
                    { new Guid("3421a07c-1d07-453b-b735-40b4dc875d0c"), 92, "https://example.com/mickey-mouse.jpg", "Mickey Mouse", "Mickey Mouse is the iconic and beloved character in Disney's cartoons.", 23.5f },
                    { new Guid("6d4fdbe4-d953-43c5-ac6c-a43a74482c94"), 92, "https://example.com/minnie.jpg", "Minnie Mouse", "Minnie Mouse is Mickey Mouse's girlfriend and one of Disney's iconic characters.", 21.4f }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("3780d224-cc9d-4b1f-8541-483ac44591b6"), "https://example.com/family.jpg", "Family" },
                    { new Guid("4cc707f6-f10e-461c-b2fe-d0c44d1c658a"), "https://example.com/animation.jpg", "Animation" },
                    { new Guid("5bc6fb2d-ef3a-4934-b67f-948b201cf01d"), "https://example.com/holiday.jpg", "Holiday" },
                    { new Guid("fa35ff16-bcd6-48f9-a26c-cc257576457c"), "https://example.com/fantasy.jpg", "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "MoviesOrSerie",
                columns: new[] { "Id", "CreationDate", "GenreId", "ImageUrl", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("0812acb8-b71e-4794-acdd-6367b157597d"), new DateTime(1940, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fa35ff16-bcd6-48f9-a26c-cc257576457c"), "https://example.com/fantasia.jpg", 7, "Fantasia" },
                    { new Guid("2ad3373e-74b3-4565-a7c4-a78b3400280f"), new DateTime(1999, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5bc6fb2d-ef3a-4934-b67f-948b201cf01d"), "https://example.com/mickeys-once-upon-a-christmas.jpg", 7, "Mickey's Once Upon a Christmas" },
                    { new Guid("475534e5-1f63-4465-ac6e-e8af62d358a6"), new DateTime(1928, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4cc707f6-f10e-461c-b2fe-d0c44d1c658a"), "https://example.com/steamboat-willie.jpg", 8, "Steamboat Willie" },
                    { new Guid("bf843eeb-0758-46bb-aebc-065dd9fd8d48"), new DateTime(1955, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3780d224-cc9d-4b1f-8541-483ac44591b6"), "https://example.com/mickey-mouse-club.jpg", 6, "The Mickey Mouse Club" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieOrSerieCharacter_MoviesOrSeriesId",
                table: "MovieOrSerieCharacter",
                column: "MoviesOrSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesOrSerie_GenreId",
                table: "MoviesOrSerie",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieOrSerieCharacter");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "MoviesOrSerie");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
