using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnalisysFormQuestionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysFormQuestionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Environment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LaboratoryAdress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LaboratoryContactInfo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LaboratoryEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ResponsibleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                name: "UserInteractionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInteractionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Analisys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AmountDonePerDay = table.Column<int>(type: "int", nullable: false),
                    EnvironmentId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analisys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analisys_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    DepartamentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EncryptedPassword = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastAcess = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    EnvironmentId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalisysForm",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AnalisysId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisysForm_Analisys_AnalisysId",
                        column: x => x.AnalisysId,
                        principalTable: "Analisys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    SoliciationTypeId = table.Column<int>(type: "int", nullable: false),
                    DesiredDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SamplesReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResultsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    AnalisysId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    EnvironmentId = table.Column<string>(type: "nvarchar(36)", nullable: true),
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
                        name: "FK_Solicitation_Analisys_AnalisysId",
                        column: x => x.AnalisysId,
                        principalTable: "Analisys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitation_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Solicitation_SolicitationTypes_SoliciationTypeId",
                        column: x => x.SoliciationTypeId,
                        principalTable: "SolicitationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInteractions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TargetId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UserInteractionTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInteractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInteractions_UserInteractionType_UserInteractionTypeId",
                        column: x => x.UserInteractionTypeId,
                        principalTable: "UserInteractionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInteractions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalisysFormQuestion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Question = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AnalisysFormId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    QuestionTypeId = table.Column<int>(type: "int", nullable: false),
                    HasOptions = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysFormQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisysFormQuestion_AnalisysFormQuestionType_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "AnalisysFormQuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnalisysFormQuestion_AnalisysForm_AnalisysFormId",
                        column: x => x.AnalisysFormId,
                        principalTable: "AnalisysForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalisysFormSubmit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    AnalisysFormId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    RequesterId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    SolicitationId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysFormSubmit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisysFormSubmit_AnalisysForm_AnalisysFormId",
                        column: x => x.AnalisysFormId,
                        principalTable: "AnalisysForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnalisysFormSubmit_Solicitation_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnalisysFormSubmit_Users_RequesterId",
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
                    SampleAnalisysExpectedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SampleAnalisysDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SampleAnalisysDone = table.Column<bool>(type: "bit", nullable: false),
                    SampleAnalysisResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalistId = table.Column<string>(type: "nvarchar(36)", nullable: false),
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
                        name: "FK_Sample_Solicitation_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sample_Users_AnalistId",
                        column: x => x.AnalistId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalisysFormQuestionOption",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Option = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysFormQuestionOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisysFormQuestionOption_AnalisysFormQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "AnalisysFormQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalisysFormAnswer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    AnalisysFormSubmitId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysFormAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisysFormAnswer_AnalisysFormQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "AnalisysFormQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnalisysFormAnswer_AnalisysFormSubmit_AnalisysFormSubmitId",
                        column: x => x.AnalisysFormSubmitId,
                        principalTable: "AnalisysFormSubmit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AnalisysFormQuestionType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "integer" },
                    { 2, "text" },
                    { 3, "boolean" },
                    { 4, "date" },
                    { 5, "time" },
                    { 6, "datetime" },
                    { 7, "decimal" },
                    { 8, "select" }
                });

            migrationBuilder.InsertData(
                table: "Environment",
                columns: new[] { "Id", "CountryName", "CreatedAt", "CreatedBy", "Deleted", "DepartmentName", "Document", "LaboratoryAdress", "LaboratoryContactInfo", "LaboratoryEmail", "Name", "ResponsibleName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "ec6248af-a61c-4dcb-9281-b50874f38cc9", "NA", new DateTime(2024, 8, 11, 19, 9, 28, 842, DateTimeKind.Local).AddTicks(8418), "c7af4e3e-ff58-4f65-a942-9f5461d65b09", false, "NA", "NA", "NA", "NA", "NA", "System Environment", "Gabriel", null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Analist" },
                    { 3, "User" }
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
                table: "UserInteractionType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Login" },
                    { 2, "Register" },
                    { 3, "Update" },
                    { 4, "Delete" },
                    { 5, "ChangePassword" },
                    { 6, "Logout" },
                    { 7, "SubmittedSamples" },
                    { 8, "TookSamples" },
                    { 9, "CompletedSamples" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "DepartamentName", "Email", "EmailConfirmed", "EncryptedPassword", "EnvironmentId", "LastAcess", "RoleId", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { "1afc400f-4dea-43b4-99f3-31638a99247f", new DateTime(2024, 8, 11, 19, 9, 28, 842, DateTimeKind.Local).AddTicks(8569), "c7af4e3e-ff58-4f65-a942-9f5461d65b09", false, "System", "ggr0910@hotmail.com", true, "Gogoll90@", "ec6248af-a61c-4dcb-9281-b50874f38cc9", null, 1, null, null, "SystemUser" });

            migrationBuilder.CreateIndex(
                name: "IX_Analisys_EnvironmentId",
                table: "Analisys",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysForm_AnalisysId",
                table: "AnalisysForm",
                column: "AnalisysId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormAnswer_AnalisysFormSubmitId",
                table: "AnalisysFormAnswer",
                column: "AnalisysFormSubmitId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormAnswer_QuestionId",
                table: "AnalisysFormAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormQuestion_AnalisysFormId",
                table: "AnalisysFormQuestion",
                column: "AnalisysFormId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormQuestion_QuestionTypeId",
                table: "AnalisysFormQuestion",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormQuestionOption_QuestionId",
                table: "AnalisysFormQuestionOption",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormSubmit_AnalisysFormId",
                table: "AnalisysFormSubmit",
                column: "AnalisysFormId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormSubmit_RequesterId",
                table: "AnalisysFormSubmit",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormSubmit_SolicitationId",
                table: "AnalisysFormSubmit",
                column: "SolicitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sample_AnalistId",
                table: "Sample",
                column: "AnalistId");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_SolicitationId",
                table: "Sample",
                column: "SolicitationId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_AnalisysId",
                table: "Solicitation",
                column: "AnalisysId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_EnvironmentId",
                table: "Solicitation",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_SoliciationTypeId",
                table: "Solicitation",
                column: "SoliciationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractions_UserId",
                table: "UserInteractions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractions_UserInteractionTypeId",
                table: "UserInteractions",
                column: "UserInteractionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EnvironmentId",
                table: "Users",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisysFormAnswer");

            migrationBuilder.DropTable(
                name: "AnalisysFormQuestionOption");

            migrationBuilder.DropTable(
                name: "Sample");

            migrationBuilder.DropTable(
                name: "UserInteractions");

            migrationBuilder.DropTable(
                name: "AnalisysFormSubmit");

            migrationBuilder.DropTable(
                name: "AnalisysFormQuestion");

            migrationBuilder.DropTable(
                name: "UserInteractionType");

            migrationBuilder.DropTable(
                name: "Solicitation");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AnalisysFormQuestionType");

            migrationBuilder.DropTable(
                name: "AnalisysForm");

            migrationBuilder.DropTable(
                name: "SolicitationTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Analisys");

            migrationBuilder.DropTable(
                name: "Environment");
        }
    }
}
