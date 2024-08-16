using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    SampleDeliverObservations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnalistsNames = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AllowWatching = table.Column<bool>(type: "bit", nullable: false),
                    LaboratoryId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analisys", x => x.Id);
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
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
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
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysFormAnswer", x => x.Id);
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
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
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
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
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
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
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
                });

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
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratory", x => x.Id);
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
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sample", x => x.Id);
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
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
                    LaboratoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UserInteractionTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "UserLaboratory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    LaboratoryId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLaboratory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLaboratory_Laboratory_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLaboratory_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLaboratory_UserLaboratory_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserLaboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLaboratory_UserLaboratory_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "UserLaboratory",
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
                    CurrentUserLaboratoryId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserLaboratory_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserLaboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserLaboratory_CurrentUserLaboratoryId",
                        column: x => x.CurrentUserLaboratoryId,
                        principalTable: "UserLaboratory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserLaboratory_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "UserLaboratory",
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
                columns: new[] { "Id", "CreatedAt", "CreatedById", "CurrentUserLaboratoryId", "Deleted", "DepartamentName", "Email", "EmailConfirmed", "EncryptedPassword", "LastAcess", "UpdatedAt", "UpdatedById", "UserName" },
                values: new object[] { "c7af4e3e-ff58-4f65-a942-9f5461d65b09", new DateTime(2024, 8, 15, 20, 31, 32, 933, DateTimeKind.Local).AddTicks(5709), null, null, false, "System", "ggr0910@hotmail.com", true, "Gogoll90@", null, null, null, "SystemUser" });

            migrationBuilder.CreateIndex(
                name: "IX_Analisys_CreatedById",
                table: "Analisys",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Analisys_LaboratoryId",
                table: "Analisys",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisys_UpdatedById",
                table: "Analisys",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysForm_AnalisysId",
                table: "AnalisysForm",
                column: "AnalisysId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysForm_CreatedById",
                table: "AnalisysForm",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysForm_UpdatedById",
                table: "AnalisysForm",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormAnswer_AnalisysFormSubmitId",
                table: "AnalisysFormAnswer",
                column: "AnalisysFormSubmitId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormAnswer_CreatedById",
                table: "AnalisysFormAnswer",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormAnswer_QuestionId",
                table: "AnalisysFormAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormAnswer_UpdatedById",
                table: "AnalisysFormAnswer",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormQuestion_AnalisysFormId",
                table: "AnalisysFormQuestion",
                column: "AnalisysFormId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormQuestion_CreatedById",
                table: "AnalisysFormQuestion",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormQuestion_QuestionTypeId",
                table: "AnalisysFormQuestion",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormQuestion_UpdatedById",
                table: "AnalisysFormQuestion",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormQuestionOption_CreatedById",
                table: "AnalisysFormQuestionOption",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormQuestionOption_QuestionId",
                table: "AnalisysFormQuestionOption",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormQuestionOption_UpdatedById",
                table: "AnalisysFormQuestionOption",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormSubmit_AnalisysFormId",
                table: "AnalisysFormSubmit",
                column: "AnalisysFormId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysFormSubmit_CreatedById",
                table: "AnalisysFormSubmit",
                column: "CreatedById");

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
                name: "IX_AnalisysFormSubmit_UpdatedById",
                table: "AnalisysFormSubmit",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratory_CreatedById",
                table: "Laboratory",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratory_UpdatedById",
                table: "Laboratory",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_AnalistId",
                table: "Sample",
                column: "AnalistId");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_CreatedById",
                table: "Sample",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_SolicitationId",
                table: "Sample",
                column: "SolicitationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_UpdatedById",
                table: "Sample",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_AnalisysId",
                table: "Solicitation",
                column: "AnalisysId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_CreatedById",
                table: "Solicitation",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_SoliciationTypeId",
                table: "Solicitation",
                column: "SoliciationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_UpdatedById",
                table: "Solicitation",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractions_CreatedById",
                table: "UserInteractions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractions_UpdatedById",
                table: "UserInteractions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractions_UserId",
                table: "UserInteractions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractions_UserInteractionTypeId",
                table: "UserInteractions",
                column: "UserInteractionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratory_CreatedById",
                table: "UserLaboratory",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratory_LaboratoryId_UserId",
                table: "UserLaboratory",
                columns: new[] { "LaboratoryId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratory_RoleId",
                table: "UserLaboratory",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratory_UpdatedById",
                table: "UserLaboratory",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratory_UserId",
                table: "UserLaboratory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CurrentUserLaboratoryId",
                table: "Users",
                column: "CurrentUserLaboratoryId",
                unique: true,
                filter: "[CurrentUserLaboratoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedById",
                table: "Users",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisys_Laboratory_LaboratoryId",
                table: "Analisys",
                column: "LaboratoryId",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analisys_UserLaboratory_CreatedById",
                table: "Analisys",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analisys_UserLaboratory_UpdatedById",
                table: "Analisys",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysForm_UserLaboratory_CreatedById",
                table: "AnalisysForm",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysForm_UserLaboratory_UpdatedById",
                table: "AnalisysForm",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormAnswer_AnalisysFormQuestion_QuestionId",
                table: "AnalisysFormAnswer",
                column: "QuestionId",
                principalTable: "AnalisysFormQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormAnswer_AnalisysFormSubmit_AnalisysFormSubmitId",
                table: "AnalisysFormAnswer",
                column: "AnalisysFormSubmitId",
                principalTable: "AnalisysFormSubmit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormAnswer_UserLaboratory_CreatedById",
                table: "AnalisysFormAnswer",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormAnswer_UserLaboratory_UpdatedById",
                table: "AnalisysFormAnswer",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormQuestion_UserLaboratory_CreatedById",
                table: "AnalisysFormQuestion",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormQuestion_UserLaboratory_UpdatedById",
                table: "AnalisysFormQuestion",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormQuestionOption_UserLaboratory_CreatedById",
                table: "AnalisysFormQuestionOption",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormQuestionOption_UserLaboratory_UpdatedById",
                table: "AnalisysFormQuestionOption",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormSubmit_Solicitation_SolicitationId",
                table: "AnalisysFormSubmit",
                column: "SolicitationId",
                principalTable: "Solicitation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormSubmit_UserLaboratory_CreatedById",
                table: "AnalisysFormSubmit",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormSubmit_UserLaboratory_UpdatedById",
                table: "AnalisysFormSubmit",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysFormSubmit_Users_RequesterId",
                table: "AnalisysFormSubmit",
                column: "RequesterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Laboratory_UserLaboratory_CreatedById",
                table: "Laboratory",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Laboratory_UserLaboratory_UpdatedById",
                table: "Laboratory",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sample_Solicitation_SolicitationId",
                table: "Sample",
                column: "SolicitationId",
                principalTable: "Solicitation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sample_UserLaboratory_CreatedById",
                table: "Sample",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sample_UserLaboratory_UpdatedById",
                table: "Sample",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sample_Users_AnalistId",
                table: "Sample",
                column: "AnalistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitation_UserLaboratory_CreatedById",
                table: "Solicitation",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitation_UserLaboratory_UpdatedById",
                table: "Solicitation",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInteractions_UserLaboratory_CreatedById",
                table: "UserInteractions",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInteractions_UserLaboratory_UpdatedById",
                table: "UserInteractions",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInteractions_Users_UserId",
                table: "UserInteractions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLaboratory_Users_UserId",
                table: "UserLaboratory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLaboratory_Laboratory_LaboratoryId",
                table: "UserLaboratory");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserLaboratory_CreatedById",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserLaboratory_CurrentUserLaboratoryId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserLaboratory_UpdatedById",
                table: "Users");

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
                name: "AnalisysFormQuestionType");

            migrationBuilder.DropTable(
                name: "AnalisysForm");

            migrationBuilder.DropTable(
                name: "SolicitationTypes");

            migrationBuilder.DropTable(
                name: "Analisys");

            migrationBuilder.DropTable(
                name: "Laboratory");

            migrationBuilder.DropTable(
                name: "UserLaboratory");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
