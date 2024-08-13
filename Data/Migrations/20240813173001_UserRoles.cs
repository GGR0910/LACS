using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1afc400f-4dea-43b4-99f3-31638a99247f");

            migrationBuilder.DeleteData(
                table: "Environment",
                keyColumn: "Id",
                keyValue: "ec6248af-a61c-4dcb-9281-b50874f38cc9");

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "AnalisysFormQuestion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Environment",
                columns: new[] { "Id", "CountryName", "CreatedAt", "CreatedBy", "Deleted", "DepartmentName", "Document", "LaboratoryAdress", "LaboratoryContactInfo", "LaboratoryEmail", "Name", "ResponsibleName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "9539e5db-4ff5-4b20-9470-eae5e1b79fd8", "NA", new DateTime(2024, 8, 13, 14, 30, 1, 25, DateTimeKind.Local).AddTicks(6344), "c7af4e3e-ff58-4f65-a942-9f5461d65b09", false, "NA", "NA", "NA", "NA", "NA", "System Environment", "Gabriel", null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Guest" },
                    { 5, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "DepartamentName", "Email", "EmailConfirmed", "EncryptedPassword", "EnvironmentId", "LastAcess", "RoleId", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "716bf500-035e-42ce-9b06-7270c3184c24", new DateTime(2024, 8, 13, 14, 30, 1, 25, DateTimeKind.Local).AddTicks(6487), "c7af4e3e-ff58-4f65-a942-9f5461d65b09", false, "System", "ggr0910@hotmail.com", true, "Gogoll90@", "9539e5db-4ff5-4b20-9470-eae5e1b79fd8", null, 5, null, null, "SystemUser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "716bf500-035e-42ce-9b06-7270c3184c24");

            migrationBuilder.DeleteData(
                table: "Environment",
                keyColumn: "Id",
                keyValue: "9539e5db-4ff5-4b20-9470-eae5e1b79fd8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "IsRequired",
                table: "AnalisysFormQuestion");

            migrationBuilder.InsertData(
                table: "Environment",
                columns: new[] { "Id", "CountryName", "CreatedAt", "CreatedBy", "Deleted", "DepartmentName", "Document", "LaboratoryAdress", "LaboratoryContactInfo", "LaboratoryEmail", "Name", "ResponsibleName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "ec6248af-a61c-4dcb-9281-b50874f38cc9", "NA", new DateTime(2024, 8, 11, 19, 9, 28, 842, DateTimeKind.Local).AddTicks(8418), "c7af4e3e-ff58-4f65-a942-9f5461d65b09", false, "NA", "NA", "NA", "NA", "NA", "System Environment", "Gabriel", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "DepartamentName", "Email", "EmailConfirmed", "EncryptedPassword", "EnvironmentId", "LastAcess", "RoleId", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "1afc400f-4dea-43b4-99f3-31638a99247f", new DateTime(2024, 8, 11, 19, 9, 28, 842, DateTimeKind.Local).AddTicks(8569), "c7af4e3e-ff58-4f65-a942-9f5461d65b09", false, "System", "ggr0910@hotmail.com", true, "Gogoll90@", "ec6248af-a61c-4dcb-9281-b50874f38cc9", null, 1, null, null, "SystemUser" });
        }
    }
}
