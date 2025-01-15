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
                name: "FormQuestionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormQuestionType", x => x.Id);
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
                name: "AnalisysForms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    FormId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    AnalisysId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    Current = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysForms", x => x.Id);
                    table.UniqueConstraint("AK_AnalisysForms_FormId_Current", x => new { x.FormId, x.Current });
                    table.ForeignKey(
                        name: "FK_AnalisysForms_Analisys_AnalisysId",
                        column: x => x.AnalisysId,
                        principalTable: "Analisys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalystAnalisysResponsible",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    AnalystId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    AnalisysId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalystAnalisysResponsible", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalystAnalisysResponsible_Analisys_AnalisysId",
                        column: x => x.AnalisysId,
                        principalTable: "Analisys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FormVersion = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormAnswer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    FormSubmitId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormAnswer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormQuestion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    QuestionInstructions = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QuestionPlaceholder = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QuestionTypeId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormQuestion_FormQuestionType_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "FormQuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormQuestionOption",
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
                    table.PrimaryKey("PK_FormQuestionOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormQuestionOption_FormQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "FormQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormSection",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormSection_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormSubmit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    FormId = table.Column<string>(type: "nvarchar(36)", nullable: false),
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
                    table.PrimaryKey("PK_FormSubmit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormSubmit_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
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
                    DefaultPassword = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DefaultDepartamentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                name: "RequesterNotes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NoteText = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Important = table.Column<bool>(type: "bit", nullable: false),
                    SolicitationId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequesterNotes", x => x.Id);
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
                    DesiredDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SamplesReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResultsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    ResponsibleAnalistId = table.Column<string>(type: "nvarchar(36)", nullable: false),
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
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    SectorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LabUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EncryptedPassword = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastAcess = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
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
                        name: "FK_Users_UserLaboratory_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "UserLaboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FormQuestionType",
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
                table: "Laboratory",
                columns: new[] { "Id", "CountryName", "CreatedAt", "CreatedById", "DefaultDepartamentName", "DefaultPassword", "Deleted", "DepartmentName", "LaboratoryAdress", "LaboratoryContactInfo", "LaboratoryEmail", "Name", "ResponsibleDocument", "ResponsibleName", "UpdatedAt", "UpdatedById" },
                values: new object[] { "2f55736e-eafd-498f-9815-80f2ce639301", "Brasil", new DateTime(2025, 1, 13, 19, 51, 48, 218, DateTimeKind.Local).AddTicks(6580), null, "Laboratório", "Teste", false, "Laboratório", "Rua dos Bobos, nº 0", "11999999999", "teste@hotmail.com", "Laboratório de Análises Clínicas", "123456789", "Admin", null, null });

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
                    { 2, "Comercial" }
                });

            migrationBuilder.InsertData(
                table: "UserInteractionType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Login" },
                    { 2, "Register" },
                    { 3, "Update" },
                    { 4, "DeleteStatusChanged" },
                    { 5, "ChangePassword" },
                    { 6, "Logout" },
                    { 7, "SubmittedSamples" },
                    { 8, "TookSamples" },
                    { 9, "CompletedSamples" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Deleted", "Email", "EmailConfirmed", "EncryptedPassword", "LastAcess", "UpdatedAt", "UpdatedById", "UserName" },
                values: new object[] { "c7af4e3e-ff58-4f65-a942-9f5461d65b09", new DateTime(2025, 1, 13, 19, 51, 48, 218, DateTimeKind.Local).AddTicks(6413), null, false, "ggr0910@hotmail.com", true, "Gogoll90@", null, null, null, "SystemUser" });

            migrationBuilder.InsertData(
                table: "UserLaboratory",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Deleted", "IsCurrent", "LabUserName", "LaboratoryId", "RoleId", "SectorName", "UpdatedAt", "UpdatedById", "UserId" },
                values: new object[] { "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(2025, 1, 13, 19, 51, 48, 218, DateTimeKind.Local).AddTicks(6622), null, false, true, "SystemUser", "2f55736e-eafd-498f-9815-80f2ce639301", 1, null, null, null, "c7af4e3e-ff58-4f65-a942-9f5461d65b09" });

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
                name: "IX_AnalisysForms_AnalisysId",
                table: "AnalisysForms",
                column: "AnalisysId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysForms_CreatedById",
                table: "AnalisysForms",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysForms_UpdatedById",
                table: "AnalisysForms",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalystAnalisysResponsible_AnalisysId",
                table: "AnalystAnalisysResponsible",
                column: "AnalisysId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalystAnalisysResponsible_AnalystId",
                table: "AnalystAnalisysResponsible",
                column: "AnalystId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalystAnalisysResponsible_CreatedById",
                table: "AnalystAnalisysResponsible",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnalystAnalisysResponsible_UpdatedById",
                table: "AnalystAnalisysResponsible",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Form_CreatedById",
                table: "Form",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Form_UpdatedById",
                table: "Form",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswer_CreatedById",
                table: "FormAnswer",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswer_FormSubmitId",
                table: "FormAnswer",
                column: "FormSubmitId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswer_QuestionId",
                table: "FormAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswer_UpdatedById",
                table: "FormAnswer",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestion_CreatedById",
                table: "FormQuestion",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestion_QuestionTypeId",
                table: "FormQuestion",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestion_SectionId",
                table: "FormQuestion",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestion_UpdatedById",
                table: "FormQuestion",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestionOption_CreatedById",
                table: "FormQuestionOption",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestionOption_QuestionId",
                table: "FormQuestionOption",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestionOption_UpdatedById",
                table: "FormQuestionOption",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormSection_CreatedById",
                table: "FormSection",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormSection_FormId",
                table: "FormSection",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSection_UpdatedById",
                table: "FormSection",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmit_CreatedById",
                table: "FormSubmit",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmit_FormId",
                table: "FormSubmit",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmit_RequesterId",
                table: "FormSubmit",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmit_SolicitationId",
                table: "FormSubmit",
                column: "SolicitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmit_UpdatedById",
                table: "FormSubmit",
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
                name: "IX_RequesterNotes_CreatedById",
                table: "RequesterNotes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RequesterNotes_SolicitationId",
                table: "RequesterNotes",
                column: "SolicitationId");

            migrationBuilder.CreateIndex(
                name: "IX_RequesterNotes_UpdatedById",
                table: "RequesterNotes",
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
                name: "IX_Solicitation_ResponsibleAnalistId",
                table: "Solicitation",
                column: "ResponsibleAnalistId");

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
                name: "FK_AnalisysForms_Form_FormId",
                table: "AnalisysForms",
                column: "FormId",
                principalTable: "Form",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysForms_UserLaboratory_CreatedById",
                table: "AnalisysForms",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisysForms_UserLaboratory_UpdatedById",
                table: "AnalisysForms",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalystAnalisysResponsible_UserLaboratory_CreatedById",
                table: "AnalystAnalisysResponsible",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalystAnalisysResponsible_UserLaboratory_UpdatedById",
                table: "AnalystAnalisysResponsible",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalystAnalisysResponsible_Users_AnalystId",
                table: "AnalystAnalisysResponsible",
                column: "AnalystId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Form_UserLaboratory_CreatedById",
                table: "Form",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Form_UserLaboratory_UpdatedById",
                table: "Form",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswer_FormQuestion_QuestionId",
                table: "FormAnswer",
                column: "QuestionId",
                principalTable: "FormQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswer_FormSubmit_FormSubmitId",
                table: "FormAnswer",
                column: "FormSubmitId",
                principalTable: "FormSubmit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswer_UserLaboratory_CreatedById",
                table: "FormAnswer",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswer_UserLaboratory_UpdatedById",
                table: "FormAnswer",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestion_FormSection_SectionId",
                table: "FormQuestion",
                column: "SectionId",
                principalTable: "FormSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestion_UserLaboratory_CreatedById",
                table: "FormQuestion",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestion_UserLaboratory_UpdatedById",
                table: "FormQuestion",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestionOption_UserLaboratory_CreatedById",
                table: "FormQuestionOption",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestionOption_UserLaboratory_UpdatedById",
                table: "FormQuestionOption",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormSection_UserLaboratory_CreatedById",
                table: "FormSection",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormSection_UserLaboratory_UpdatedById",
                table: "FormSection",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormSubmit_Solicitation_SolicitationId",
                table: "FormSubmit",
                column: "SolicitationId",
                principalTable: "Solicitation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormSubmit_UserLaboratory_CreatedById",
                table: "FormSubmit",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormSubmit_UserLaboratory_UpdatedById",
                table: "FormSubmit",
                column: "UpdatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormSubmit_Users_RequesterId",
                table: "FormSubmit",
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
                name: "FK_RequesterNotes_Solicitation_SolicitationId",
                table: "RequesterNotes",
                column: "SolicitationId",
                principalTable: "Solicitation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequesterNotes_UserLaboratory_CreatedById",
                table: "RequesterNotes",
                column: "CreatedById",
                principalTable: "UserLaboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequesterNotes_UserLaboratory_UpdatedById",
                table: "RequesterNotes",
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
                name: "FK_Solicitation_Users_ResponsibleAnalistId",
                table: "Solicitation",
                column: "ResponsibleAnalistId",
                principalTable: "Users",
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
                name: "FK_Users_UserLaboratory_UpdatedById",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AnalisysForms");

            migrationBuilder.DropTable(
                name: "AnalystAnalisysResponsible");

            migrationBuilder.DropTable(
                name: "FormAnswer");

            migrationBuilder.DropTable(
                name: "FormQuestionOption");

            migrationBuilder.DropTable(
                name: "RequesterNotes");

            migrationBuilder.DropTable(
                name: "Sample");

            migrationBuilder.DropTable(
                name: "UserInteractions");

            migrationBuilder.DropTable(
                name: "FormSubmit");

            migrationBuilder.DropTable(
                name: "FormQuestion");

            migrationBuilder.DropTable(
                name: "UserInteractionType");

            migrationBuilder.DropTable(
                name: "Solicitation");

            migrationBuilder.DropTable(
                name: "FormQuestionType");

            migrationBuilder.DropTable(
                name: "FormSection");

            migrationBuilder.DropTable(
                name: "Analisys");

            migrationBuilder.DropTable(
                name: "SolicitationTypes");

            migrationBuilder.DropTable(
                name: "Form");

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
