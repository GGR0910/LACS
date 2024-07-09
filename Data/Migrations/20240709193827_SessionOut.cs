using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SessionOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIJWTSession");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "06240d1c-e077-4b51-b400-0dc5da925402");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "Deleted", "Email", "EmailConfirmed", "EncryptedPassword", "LastAcess", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "54ef8ed9-668c-4389-a638-9460e4806587", true, new DateTime(2024, 7, 9, 16, 38, 26, 905, DateTimeKind.Local).AddTicks(9626), "9f929feb-1db6-4fc2-b630-9ee1d47abc50", false, "ggr0910@hotmail.com", false, "Gogoll90@", null, null, null, "SystemUser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "54ef8ed9-668c-4389-a638-9460e4806587");

            migrationBuilder.CreateTable(
                name: "APIJWTSession",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    DateLimitToUse = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    JWTKeyUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIJWTSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_APIJWTSession_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "Deleted", "Email", "EmailConfirmed", "EncryptedPassword", "LastAcess", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "06240d1c-e077-4b51-b400-0dc5da925402", true, new DateTime(2024, 7, 9, 14, 49, 34, 978, DateTimeKind.Local).AddTicks(7700), "6a3bbcb5-b307-42a8-bfae-3d784cfd359e", false, "ggr0910@hotmail.com", false, "Gogoll90@", null, null, null, "SystemUser" });

            migrationBuilder.CreateIndex(
                name: "IX_APIJWTSession_UserId",
                table: "APIJWTSession",
                column: "UserId");
        }
    }
}
