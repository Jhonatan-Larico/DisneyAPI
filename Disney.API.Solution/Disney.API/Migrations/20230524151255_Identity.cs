using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Disney.API.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "Id",
                keyValue: new Guid("3421a07c-1d07-453b-b735-40b4dc875d0c"));

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "Id",
                keyValue: new Guid("6d4fdbe4-d953-43c5-ac6c-a43a74482c94"));

            migrationBuilder.DeleteData(
                table: "MoviesOrSerie",
                keyColumn: "Id",
                keyValue: new Guid("0812acb8-b71e-4794-acdd-6367b157597d"));

            migrationBuilder.DeleteData(
                table: "MoviesOrSerie",
                keyColumn: "Id",
                keyValue: new Guid("2ad3373e-74b3-4565-a7c4-a78b3400280f"));

            migrationBuilder.DeleteData(
                table: "MoviesOrSerie",
                keyColumn: "Id",
                keyValue: new Guid("475534e5-1f63-4465-ac6e-e8af62d358a6"));

            migrationBuilder.DeleteData(
                table: "MoviesOrSerie",
                keyColumn: "Id",
                keyValue: new Guid("bf843eeb-0758-46bb-aebc-065dd9fd8d48"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("3780d224-cc9d-4b1f-8541-483ac44591b6"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("4cc707f6-f10e-461c-b2fe-d0c44d1c658a"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("5bc6fb2d-ef3a-4934-b67f-948b201cf01d"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("fa35ff16-bcd6-48f9-a26c-cc257576457c"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Age", "ImageUrl", "Name", "Story", "Weight" },
                values: new object[,]
                {
                    { new Guid("2c3f4ba5-fbc9-41ab-8a1e-2beba94bd859"), 92, "https://example.com/minnie.jpg", "Minnie Mouse", "Minnie Mouse is Mickey Mouse's girlfriend and one of Disney's iconic characters.", 21.4f },
                    { new Guid("6e565601-cad3-4216-b1a4-5748639f7356"), 92, "https://example.com/mickey-mouse.jpg", "Mickey Mouse", "Mickey Mouse is the iconic and beloved character in Disney's cartoons.", 23.5f }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("26a2ab41-02aa-4cd5-9255-09af5c6f68c0"), "https://example.com/animation.jpg", "Animation" },
                    { new Guid("7ec908da-bbb2-4a16-bbf7-6cc6e1b96f65"), "https://example.com/family.jpg", "Family" },
                    { new Guid("bb649169-a395-40bd-9108-63748dc780b4"), "https://example.com/holiday.jpg", "Holiday" },
                    { new Guid("e1e62e8e-0783-4950-b38c-222b4b1be7bb"), "https://example.com/fantasy.jpg", "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "MoviesOrSerie",
                columns: new[] { "Id", "CreationDate", "GenreId", "ImageUrl", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("136e2edb-aa11-48e5-a30b-5a5574c5a2b5"), new DateTime(1928, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("26a2ab41-02aa-4cd5-9255-09af5c6f68c0"), "https://example.com/steamboat-willie.jpg", 8, "Steamboat Willie" },
                    { new Guid("aa9a826c-116a-4989-8cee-685a0e113ac8"), new DateTime(1955, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7ec908da-bbb2-4a16-bbf7-6cc6e1b96f65"), "https://example.com/mickey-mouse-club.jpg", 6, "The Mickey Mouse Club" },
                    { new Guid("cdb91809-819a-4aa8-a053-1165a596167d"), new DateTime(1940, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1e62e8e-0783-4950-b38c-222b4b1be7bb"), "https://example.com/fantasia.jpg", 7, "Fantasia" },
                    { new Guid("d0f1ed24-11e0-4015-b9f9-56f5b5789f4e"), new DateTime(1999, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bb649169-a395-40bd-9108-63748dc780b4"), "https://example.com/mickeys-once-upon-a-christmas.jpg", 7, "Mickey's Once Upon a Christmas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "Id",
                keyValue: new Guid("2c3f4ba5-fbc9-41ab-8a1e-2beba94bd859"));

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "Id",
                keyValue: new Guid("6e565601-cad3-4216-b1a4-5748639f7356"));

            migrationBuilder.DeleteData(
                table: "MoviesOrSerie",
                keyColumn: "Id",
                keyValue: new Guid("136e2edb-aa11-48e5-a30b-5a5574c5a2b5"));

            migrationBuilder.DeleteData(
                table: "MoviesOrSerie",
                keyColumn: "Id",
                keyValue: new Guid("aa9a826c-116a-4989-8cee-685a0e113ac8"));

            migrationBuilder.DeleteData(
                table: "MoviesOrSerie",
                keyColumn: "Id",
                keyValue: new Guid("cdb91809-819a-4aa8-a053-1165a596167d"));

            migrationBuilder.DeleteData(
                table: "MoviesOrSerie",
                keyColumn: "Id",
                keyValue: new Guid("d0f1ed24-11e0-4015-b9f9-56f5b5789f4e"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("26a2ab41-02aa-4cd5-9255-09af5c6f68c0"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("7ec908da-bbb2-4a16-bbf7-6cc6e1b96f65"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("bb649169-a395-40bd-9108-63748dc780b4"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("e1e62e8e-0783-4950-b38c-222b4b1be7bb"));

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
        }
    }
}
