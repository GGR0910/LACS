using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Laboratory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisys_Environment_EnvironmentId",
                table: "Analisys");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitation_Environment_EnvironmentId",
                table: "Solicitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Environment_EnvironmentId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Environment");

            migrationBuilder.DropIndex(
                name: "IX_Users_EnvironmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Solicitation_EnvironmentId",
                table: "Solicitation");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "716bf500-035e-42ce-9b06-7270c3184c24");

            migrationBuilder.DropColumn(
                name: "EnvironmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EnvironmentId",
                table: "Solicitation");

            migrationBuilder.RenameColumn(
                name: "EnvironmentId",
                table: "Analisys",
                newName: "LaboratoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Analisys_EnvironmentId",
                table: "Analisys",
                newName: "IX_Analisys_LaboratoryId");

            migrationBuilder.AddColumn<string>(
                name: "LaboratoryId",
                table: "Users",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LaboratoryId",
                table: "UserInteractions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SampleDeliverObservations",
                table: "Analisys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Laboratory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ResponsibleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ResponsibleDocument = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LaboratoryAdress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LaboratoryContactInfo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LaboratoryEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Laboratory",
                columns: new[] { "Id", "CountryName", "CreatedAt", "CreatedBy", "Deleted", "DepartmentName", "LaboratoryAdress", "LaboratoryContactInfo", "LaboratoryEmail", "Name", "ResponsibleDocument", "ResponsibleName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "bd65758a-5488-4feb-a717-5ac7923300bd", "NA", new DateTime(2024, 8, 14, 12, 37, 58, 267, DateTimeKind.Local).AddTicks(9916), "c7af4e3e-ff58-4f65-a942-9f5461d65b09", false, "NA", "NA", "NA", "NA", "System Environment", "NA", "Gabriel", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "DepartamentName", "Email", "EmailConfirmed", "EncryptedPassword", "LaboratoryId", "LastAcess", "RoleId", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "c7af4e3e-ff58-4f65-a942-9f5461d65b09", new DateTime(2024, 8, 14, 12, 37, 58, 268, DateTimeKind.Local).AddTicks(69), "c7af4e3e-ff58-4f65-a942-9f5461d65b09", false, "System", "ggr0910@hotmail.com", true, "Gogoll90@", "bd65758a-5488-4feb-a717-5ac7923300bd", null, 5, null, null, "SystemUser" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LaboratoryId",
                table: "Users",
                column: "LaboratoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisys_Laboratory_LaboratoryId",
                table: "Analisys",
                column: "LaboratoryId",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Laboratory_LaboratoryId",
                table: "Users",
                column: "LaboratoryId",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisys_Laboratory_LaboratoryId",
                table: "Analisys");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Laboratory_LaboratoryId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Laboratory");

            migrationBuilder.DropIndex(
                name: "IX_Users_LaboratoryId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c7af4e3e-ff58-4f65-a942-9f5461d65b09");

            migrationBuilder.DropColumn(
                name: "LaboratoryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LaboratoryId",
                table: "UserInteractions");

            migrationBuilder.DropColumn(
                name: "SampleDeliverObservations",
                table: "Analisys");

            migrationBuilder.RenameColumn(
                name: "LaboratoryId",
                table: "Analisys",
                newName: "EnvironmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Analisys_LaboratoryId",
                table: "Analisys",
                newName: "IX_Analisys_EnvironmentId");

            migrationBuilder.AddColumn<string>(
                name: "EnvironmentId",
                table: "Users",
                type: "nvarchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnvironmentId",
                table: "Solicitation",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Environment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LaboratoryAdress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LaboratoryContactInfo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LaboratoryEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ResponsibleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environment", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Environment",
                columns: new[] { "Id", "CountryName", "CreatedAt", "CreatedBy", "Deleted", "DepartmentName", "Document", "LaboratoryAdress", "LaboratoryContactInfo", "LaboratoryEmail", "Name", "ResponsibleName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "9539e5db-4ff5-4b20-9470-eae5e1b79fd8", "NA", new DateTime(2024, 8, 13, 14, 30, 1, 25, DateTimeKind.Local).AddTicks(6344), "c7af4e3e-ff58-4f65-a942-9f5461d65b09", false, "NA", "NA", "NA", "NA", "NA", "System Environment", "Gabriel", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "DepartamentName", "Email", "EmailConfirmed", "EncryptedPassword", "EnvironmentId", "LastAcess", "RoleId", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "716bf500-035e-42ce-9b06-7270c3184c24", new DateTime(2024, 8, 13, 14, 30, 1, 25, DateTimeKind.Local).AddTicks(6487), "c7af4e3e-ff58-4f65-a942-9f5461d65b09", false, "System", "ggr0910@hotmail.com", true, "Gogoll90@", "9539e5db-4ff5-4b20-9470-eae5e1b79fd8", null, 5, null, null, "SystemUser" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EnvironmentId",
                table: "Users",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_EnvironmentId",
                table: "Solicitation",
                column: "EnvironmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisys_Environment_EnvironmentId",
                table: "Analisys",
                column: "EnvironmentId",
                principalTable: "Environment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitation_Environment_EnvironmentId",
                table: "Solicitation",
                column: "EnvironmentId",
                principalTable: "Environment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Environment_EnvironmentId",
                table: "Users",
                column: "EnvironmentId",
                principalTable: "Environment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
