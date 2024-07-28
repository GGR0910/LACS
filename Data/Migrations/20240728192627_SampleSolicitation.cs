using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SampleSolicitation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b7dffc35-52da-4c75-84b6-d93a2da6c027");

            migrationBuilder.AddColumn<string>(
                name: "DepartamentName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AnalisysTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SamplePhisicalStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamplePhisicalStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolicitationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    RequesterId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    SoliciationTypeId = table.Column<int>(type: "int", nullable: false),
                    SamplesDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AnalysisGoalDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AnalisysTypeId = table.Column<int>(type: "int", nullable: false),
                    DesiredMagnefication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeedsRecobriment = table.Column<bool>(type: "bit", nullable: false),
                    RecobrimentMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialPrecautions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesiredDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesireToAccompanyAnalysis = table.Column<bool>(type: "bit", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamplesReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResultsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitation_AnalisysTypes_AnalisysTypeId",
                        column: x => x.AnalisysTypeId,
                        principalTable: "AnalisysTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitation_SolicitationTypes_SoliciationTypeId",
                        column: x => x.SoliciationTypeId,
                        principalTable: "SolicitationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitation_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sample",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    SolicitationId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    SampleTypeId = table.Column<int>(type: "int", nullable: false),
                    SamplePhisicalStateId = table.Column<int>(type: "int", nullable: false),
                    SampleAnalysisStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SampleAnalysisEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SampleAnalysisResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalistyId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sample_SamplePhisicalStates_SamplePhisicalStateId",
                        column: x => x.SamplePhisicalStateId,
                        principalTable: "SamplePhisicalStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sample_SampleTypes_SampleTypeId",
                        column: x => x.SampleTypeId,
                        principalTable: "SampleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sample_Solicitation_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sample_Users_AnalistyId",
                        column: x => x.AnalistyId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AnalisysTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Morfological_SE" },
                    { 2, "ZContrast_BSE" },
                    { 3, "Composition_EDS" }
                });

            migrationBuilder.InsertData(
                table: "SamplePhisicalStates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dust" },
                    { 2, "Pieces" },
                    { 3, "Film" },
                    { 4, "Other" }
                });

            migrationBuilder.InsertData(
                table: "SampleTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Polimeric" },
                    { 2, "Metalic" },
                    { 3, "Ceramic" },
                    { 4, "Biologic" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "SolicitationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Academic" },
                    { 2, "ServicePrestation" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "Deleted", "DepartamentName", "Email", "EmailConfirmed", "EncryptedPassword", "LastAcess", "RoleId", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "7d22b3ce-a2b3-40a8-bdbc-b6f309f26ca0", true, new DateTime(2024, 7, 28, 16, 26, 27, 444, DateTimeKind.Local).AddTicks(3671), "56c348a4-786a-41ca-a0e1-37aa20341390", false, "System", "ggr0910@hotmail.com", true, "Gogoll90@", null, 1, null, null, "SystemUser" });

            migrationBuilder.CreateIndex(
                name: "IX_Sample_AnalistyId",
                table: "Sample",
                column: "AnalistyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_SamplePhisicalStateId",
                table: "Sample",
                column: "SamplePhisicalStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_SampleTypeId",
                table: "Sample",
                column: "SampleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_SolicitationId",
                table: "Sample",
                column: "SolicitationId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_AnalisysTypeId",
                table: "Solicitation",
                column: "AnalisysTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_RequesterId",
                table: "Solicitation",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_SoliciationTypeId",
                table: "Solicitation",
                column: "SoliciationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sample");

            migrationBuilder.DropTable(
                name: "SamplePhisicalStates");

            migrationBuilder.DropTable(
                name: "SampleTypes");

            migrationBuilder.DropTable(
                name: "Solicitation");

            migrationBuilder.DropTable(
                name: "AnalisysTypes");

            migrationBuilder.DropTable(
                name: "SolicitationTypes");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d22b3ce-a2b3-40a8-bdbc-b6f309f26ca0");

            migrationBuilder.DropColumn(
                name: "DepartamentName",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "Deleted", "Email", "EmailConfirmed", "EncryptedPassword", "LastAcess", "RoleId", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "b7dffc35-52da-4c75-84b6-d93a2da6c027", true, new DateTime(2024, 7, 26, 16, 57, 25, 993, DateTimeKind.Local).AddTicks(2759), "95000224-6d9b-44aa-adc2-92de81419a73", false, "ggr0910@hotmail.com", true, "Gogoll90@", null, 1, null, null, "SystemUser" });
        }
    }
}
