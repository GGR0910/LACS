﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240811140730_CollumNameCorrection")]
    partial class CollumNameCorrection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AnalisysType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnalisysTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Morfological_SE"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ZContrast_BSE"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Composition_EDS"
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
                        });
                });

            modelBuilder.Entity("Domain.Entities.Sample", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("AnalistId")
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

                    b.Property<int>("SamplePhisicalStateId")
                        .HasColumnType("int");

                    b.Property<int>("SampleTypeId")
                        .HasColumnType("int");

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

                    b.HasIndex("SamplePhisicalStateId");

                    b.HasIndex("SampleTypeId");

                    b.HasIndex("SolicitationId");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("Domain.Entities.SamplePhisicalState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SamplePhisicalStates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dust"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pieces"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Film"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Domain.Entities.SampleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SampleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Polimeric"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Metalic"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ceramic"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Biologic"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Solicitation", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("AnalisysTypeId")
                        .HasColumnType("int");

                    b.Property<string>("AnalysisGoalDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

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

                    b.Property<string>("DeliveryLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DesireToAccompanyAnalysis")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DesiredDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("DesiredMagnefication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpectedCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("NeedsRecobriment")
                        .HasColumnType("bit");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecobrimentMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequesterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("ResultsDelivered")
                        .HasColumnType("bit");

                    b.Property<string>("SamplesDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("SamplesReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoliciationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialPrecautions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("AnalisysTypeId");

                    b.HasIndex("RequesterId");

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

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

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

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "0dc496e6-85f0-408c-9564-6225232130b3",
                            Active = true,
                            CreatedAt = new DateTime(2024, 8, 11, 11, 7, 29, 970, DateTimeKind.Local).AddTicks(6499),
                            CreatedBy = "c7af4e3e-ff58-4f65-a942-9f5461d65b09",
                            Deleted = false,
                            DepartamentName = "System",
                            Email = "ggr0910@hotmail.com",
                            EmailConfirmed = true,
                            EncryptedPassword = "Gogoll90@",
                            RoleId = 1,
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

            modelBuilder.Entity("Domain.Entities.Sample", b =>
                {
                    b.HasOne("Domain.Entities.User", "Analist")
                        .WithMany("Samples")
                        .HasForeignKey("AnalistId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.SamplePhisicalState", "SamplePhisicalState")
                        .WithMany("Samples")
                        .HasForeignKey("SamplePhisicalStateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.SampleType", "SampleType")
                        .WithMany("Samples")
                        .HasForeignKey("SampleTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Solicitation", "Solicitation")
                        .WithMany("Samples")
                        .HasForeignKey("SolicitationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Analist");

                    b.Navigation("SamplePhisicalState");

                    b.Navigation("SampleType");

                    b.Navigation("Solicitation");
                });

            modelBuilder.Entity("Domain.Entities.Solicitation", b =>
                {
                    b.HasOne("Domain.Entities.AnalisysType", "AnalisysType")
                        .WithMany("Solicitations")
                        .HasForeignKey("AnalisysTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "Requester")
                        .WithMany("Solicitations")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.SolicitationType", "SolicitationType")
                        .WithMany("Solicitations")
                        .HasForeignKey("SoliciationTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AnalisysType");

                    b.Navigation("Requester");

                    b.Navigation("SolicitationType");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

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

            modelBuilder.Entity("Domain.Entities.AnalisysType", b =>
                {
                    b.Navigation("Solicitations");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.SamplePhisicalState", b =>
                {
                    b.Navigation("Samples");
                });

            modelBuilder.Entity("Domain.Entities.SampleType", b =>
                {
                    b.Navigation("Samples");
                });

            modelBuilder.Entity("Domain.Entities.Solicitation", b =>
                {
                    b.Navigation("Samples");
                });

            modelBuilder.Entity("Domain.Entities.SolicitationType", b =>
                {
                    b.Navigation("Solicitations");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Samples");

                    b.Navigation("Solicitations");

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
