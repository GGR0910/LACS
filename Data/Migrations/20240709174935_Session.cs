using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Session : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIJWTSession",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    JWTKeyUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    DateLimitToUse = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIJWTSession");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "06240d1c-e077-4b51-b400-0dc5da925402");
        }
    }
}
