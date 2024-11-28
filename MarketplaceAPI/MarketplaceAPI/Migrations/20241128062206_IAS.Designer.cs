﻿// <auto-generated />
using System;
using MarketplaceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarketplaceAPI.Migrations
{
    [DbContext(typeof(DBContextMarketplace))]
    [Migration("20241128062206_IAS")]
    partial class IAS
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarketplaceAPI.Models.Chat", b =>
                {
                    b.Property<int>("idChat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idChat"));

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("idProject")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("idChat");

                    b.HasIndex("idProject");

                    b.HasIndex("idUser");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Evaluation", b =>
                {
                    b.Property<int>("idEvaluation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEvaluation"));

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("idEvaluatedUser")
                        .HasColumnType("int");

                    b.Property<int>("idEvaluatorUser")
                        .HasColumnType("int");

                    b.Property<int>("idProject")
                        .HasColumnType("int");

                    b.Property<string>("nameEvaluated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.HasKey("idEvaluation");

                    b.HasIndex("idEvaluatedUser");

                    b.HasIndex("idEvaluatorUser");

                    b.HasIndex("idProject");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Message", b =>
                {
                    b.Property<int>("idMessage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idMessage"));

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("idChat")
                        .HasColumnType("int");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("sender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("idMessage");

                    b.HasIndex("idChat");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Notification", b =>
                {
                    b.Property<int>("idNotification")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idNotification"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("idProject")
                        .HasColumnType("int");

                    b.Property<int?>("idUserCollaborator")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idNotification");

                    b.HasIndex("idProject");

                    b.HasIndex("idUserCollaborator");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Project", b =>
                {
                    b.Property<int>("idProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProject"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPublication")
                        .HasColumnType("int");

                    b.Property<int>("idUserRequester")
                        .HasColumnType("int");

                    b.Property<string>("nameProject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("stateProject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idProject");

                    b.HasIndex("idPublication");

                    b.HasIndex("idUserRequester");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MarketplaceAPI.Models.ProjectContributor", b =>
                {
                    b.Property<int>("idProject")
                        .HasColumnType("int");

                    b.Property<int>("idUserContributor")
                        .HasColumnType("int");

                    b.Property<DateTime>("applicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("nameContributor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("idProject", "idUserContributor");

                    b.HasIndex("idUserContributor");

                    b.ToTable("ProjectContributors");
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Publication", b =>
                {
                    b.Property<int>("idPublication")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPublication"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("publicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idPublication");

                    b.HasIndex("idUser");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Role", b =>
                {
                    b.Property<int>("idRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRole"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idRole");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MarketplaceAPI.Models.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUser"));

                    b.Property<string>("country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("idRole")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("linkedIn")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("portfolio")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("idUser");

                    b.HasIndex("idRole");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Chat", b =>
                {
                    b.HasOne("MarketplaceAPI.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("idProject")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarketplaceAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Evaluation", b =>
                {
                    b.HasOne("MarketplaceAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("idEvaluatedUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarketplaceAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("idEvaluatorUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarketplaceAPI.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("idProject")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Message", b =>
                {
                    b.HasOne("MarketplaceAPI.Models.Chat", null)
                        .WithMany()
                        .HasForeignKey("idChat")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Notification", b =>
                {
                    b.HasOne("MarketplaceAPI.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("idProject")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarketplaceAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("idUserCollaborator")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Project", b =>
                {
                    b.HasOne("MarketplaceAPI.Models.Publication", null)
                        .WithMany()
                        .HasForeignKey("idPublication")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarketplaceAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("idUserRequester")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MarketplaceAPI.Models.ProjectContributor", b =>
                {
                    b.HasOne("MarketplaceAPI.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("idProject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketplaceAPI.Models.User", "Applicant")
                        .WithMany("ProjectApplications")
                        .HasForeignKey("idUserContributor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("MarketplaceAPI.Models.Publication", b =>
                {
                    b.HasOne("MarketplaceAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MarketplaceAPI.Models.User", b =>
                {
                    b.HasOne("MarketplaceAPI.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("idRole")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MarketplaceAPI.Models.User", b =>
                {
                    b.Navigation("ProjectApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
