﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Analisys", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("AmountDonePerDay")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EnvironmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("EnvironmentId");

                    b.ToTable("Analisys");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysForm", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("AnalisysId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("AnalisysId")
                        .IsUnique();

                    b.ToTable("AnalisysForm");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormAnswer", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("AnalisysFormSubmitId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("AnalisysFormSubmitId");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnalisysFormAnswer");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormQuestion", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("AnalisysFormId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("HasOptions")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("QuestionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("AnalisysFormId");

                    b.HasIndex("QuestionTypeId");

                    b.ToTable("AnalisysFormQuestion");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormQuestionOption", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnalisysFormQuestionOption");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormQuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnalisysFormQuestionType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "integer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "text"
                        },
                        new
                        {
                            Id = 3,
                            Name = "boolean"
                        },
                        new
                        {
                            Id = 4,
                            Name = "date"
                        },
                        new
                        {
                            Id = 5,
                            Name = "time"
                        },
                        new
                        {
                            Id = 6,
                            Name = "datetime"
                        },
                        new
                        {
                            Id = 7,
                            Name = "decimal"
                        },
                        new
                        {
                            Id = 8,
                            Name = "select"
                        });
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormSubmit", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("AnalisysFormId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("RequesterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("SolicitationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("AnalisysFormId");

                    b.HasIndex("RequesterId");

                    b.HasIndex("SolicitationId")
                        .IsUnique();

                    b.ToTable("AnalisysFormSubmit");
                });

            modelBuilder.Entity("Domain.Entities.Environment", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LaboratoryAdress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LaboratoryContactInfo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LaboratoryEmail")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ResponsibleName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.ToTable("Environment");

                    b.HasData(
                        new
                        {
                            Id = "9539e5db-4ff5-4b20-9470-eae5e1b79fd8",
                            CountryName = "NA",
                            CreatedAt = new DateTime(2024, 8, 13, 14, 30, 1, 25, DateTimeKind.Local).AddTicks(6344),
                            CreatedBy = "c7af4e3e-ff58-4f65-a942-9f5461d65b09",
                            Deleted = false,
                            DepartmentName = "NA",
                            Document = "NA",
                            LaboratoryAdress = "NA",
                            LaboratoryContactInfo = "NA",
                            LaboratoryEmail = "NA",
                            Name = "System Environment",
                            ResponsibleName = "Gabriel"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Analist"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Guest"
                        },
                        new
                        {
                            Id = 5,
                            Name = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Sample", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("AnalistId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SampleAnalisysDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("SampleAnalisysDone")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SampleAnalisysExpectedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SampleAnalysisResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolicitationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("AnalistId");

                    b.HasIndex("SolicitationId");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("Domain.Entities.Solicitation", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("AnalisysId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DesiredDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnvironmentId")
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime?>("ExpectedCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ResultsDelivered")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SamplesReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoliciationTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("AnalisysId");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("SoliciationTypeId");

                    b.ToTable("Solicitation");
                });

            modelBuilder.Entity("Domain.Entities.SolicitationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SolicitationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Academic"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ServicePrestation"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("DepartamentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("EncryptedPassword")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EnvironmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime?>("LastAcess")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "716bf500-035e-42ce-9b06-7270c3184c24",
                            CreatedAt = new DateTime(2024, 8, 13, 14, 30, 1, 25, DateTimeKind.Local).AddTicks(6487),
                            CreatedBy = "c7af4e3e-ff58-4f65-a942-9f5461d65b09",
                            Deleted = false,
                            DepartamentName = "System",
                            Email = "ggr0910@hotmail.com",
                            EmailConfirmed = true,
                            EncryptedPassword = "Gogoll90@",
                            EnvironmentId = "9539e5db-4ff5-4b20-9470-eae5e1b79fd8",
                            RoleId = 5,
                            UserName = "SystemUser"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserInteraction", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TargetId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("UserInteractionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserInteractionTypeId");

                    b.ToTable("UserInteractions");
                });

            modelBuilder.Entity("Domain.Entities.UserInteractionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserInteractionType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Login"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Register"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Update"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Delete"
                        },
                        new
                        {
                            Id = 5,
                            Name = "ChangePassword"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Logout"
                        },
                        new
                        {
                            Id = 7,
                            Name = "SubmittedSamples"
                        },
                        new
                        {
                            Id = 8,
                            Name = "TookSamples"
                        },
                        new
                        {
                            Id = 9,
                            Name = "CompletedSamples"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Analisys", b =>
                {
                    b.HasOne("Domain.Entities.Environment", "Environment")
                        .WithMany("Analisys")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Environment");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysForm", b =>
                {
                    b.HasOne("Domain.Entities.Analisys", "Analisys")
                        .WithOne("AnalisysForm")
                        .HasForeignKey("Domain.Entities.AnalisysForm", "AnalisysId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Analisys");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormAnswer", b =>
                {
                    b.HasOne("Domain.Entities.AnalisysFormSubmit", "Submission")
                        .WithMany("Answers")
                        .HasForeignKey("AnalisysFormSubmitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AnalisysFormQuestion", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormQuestion", b =>
                {
                    b.HasOne("Domain.Entities.AnalisysForm", "AnalisysForm")
                        .WithMany("Questions")
                        .HasForeignKey("AnalisysFormId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AnalisysFormQuestionType", "QuestionType")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AnalisysForm");

                    b.Navigation("QuestionType");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormQuestionOption", b =>
                {
                    b.HasOne("Domain.Entities.AnalisysFormQuestion", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormSubmit", b =>
                {
                    b.HasOne("Domain.Entities.AnalisysForm", "Form")
                        .WithMany("Submissions")
                        .HasForeignKey("AnalisysFormId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "Requester")
                        .WithMany("Submissions")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Solicitation", "Solicitation")
                        .WithOne("AnalisysFormSubmit")
                        .HasForeignKey("Domain.Entities.AnalisysFormSubmit", "SolicitationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("Requester");

                    b.Navigation("Solicitation");
                });

            modelBuilder.Entity("Domain.Entities.Sample", b =>
                {
                    b.HasOne("Domain.Entities.User", "Analist")
                        .WithMany("Samples")
                        .HasForeignKey("AnalistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Solicitation", "Solicitation")
                        .WithMany("Samples")
                        .HasForeignKey("SolicitationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Analist");

                    b.Navigation("Solicitation");
                });

            modelBuilder.Entity("Domain.Entities.Solicitation", b =>
                {
                    b.HasOne("Domain.Entities.Analisys", "Analisys")
                        .WithMany("Solicitations")
                        .HasForeignKey("AnalisysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Environment", null)
                        .WithMany("Solicitations")
                        .HasForeignKey("EnvironmentId");

                    b.HasOne("Domain.Entities.SolicitationType", "SolicitationType")
                        .WithMany("Solicitations")
                        .HasForeignKey("SoliciationTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Analisys");

                    b.Navigation("SolicitationType");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Environment", "Environment")
                        .WithMany()
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Environment");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.UserInteraction", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserInteractions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserInteractionType", "UserInteractionType")
                        .WithMany("UserInteractions")
                        .HasForeignKey("UserInteractionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserInteractionType");
                });

            modelBuilder.Entity("Domain.Entities.Analisys", b =>
                {
                    b.Navigation("AnalisysForm")
                        .IsRequired();

                    b.Navigation("Solicitations");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysForm", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormQuestion", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormQuestionType", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Domain.Entities.AnalisysFormSubmit", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Domain.Entities.Environment", b =>
                {
                    b.Navigation("Analisys");

                    b.Navigation("Solicitations");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.Solicitation", b =>
                {
                    b.Navigation("AnalisysFormSubmit")
                        .IsRequired();

                    b.Navigation("Samples");
                });

            modelBuilder.Entity("Domain.Entities.SolicitationType", b =>
                {
                    b.Navigation("Solicitations");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Samples");

                    b.Navigation("Submissions");

                    b.Navigation("UserInteractions");
                });

            modelBuilder.Entity("Domain.Entities.UserInteractionType", b =>
                {
                    b.Navigation("UserInteractions");
                });
#pragma warning restore 612, 618
        }
    }
}
