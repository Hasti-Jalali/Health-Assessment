﻿// <auto-generated />
using System;
using HealthAssessment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HealthAssessment.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20211210091742_changeFields1")]
    partial class changeFields1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("FormFormQuestion", b =>
                {
                    b.Property<int>("FormQuestionsId")
                        .HasColumnType("integer");

                    b.Property<int>("FormsId")
                        .HasColumnType("integer");

                    b.HasKey("FormQuestionsId", "FormsId");

                    b.HasIndex("FormsId");

                    b.ToTable("FormFormQuestion");
                });

            modelBuilder.Entity("FormQuestionQuestion", b =>
                {
                    b.Property<int>("FormQuestionsId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionsId")
                        .HasColumnType("integer");

                    b.HasKey("FormQuestionsId", "QuestionsId");

                    b.HasIndex("QuestionsId");

                    b.ToTable("FormQuestionQuestion");
                });

            modelBuilder.Entity("HealthAssessment.Models.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int?>("UserFormId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserFormId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("HealthAssessment.Models.FormQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FormId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("FormQuestions");
                });

            modelBuilder.Entity("HealthAssessment.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("HealthAssessment.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HealthAssessment.Models.UserForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FormId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserForms");
                });

            modelBuilder.Entity("HealthAssessment.Models.UserFormResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FormId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("Result")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFormResults");
                });

            modelBuilder.Entity("UserUserForm", b =>
                {
                    b.Property<int>("UserFormsId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("UserFormsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserUserForm");
                });

            modelBuilder.Entity("FormFormQuestion", b =>
                {
                    b.HasOne("HealthAssessment.Models.FormQuestion", null)
                        .WithMany()
                        .HasForeignKey("FormQuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthAssessment.Models.Form", null)
                        .WithMany()
                        .HasForeignKey("FormsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FormQuestionQuestion", b =>
                {
                    b.HasOne("HealthAssessment.Models.FormQuestion", null)
                        .WithMany()
                        .HasForeignKey("FormQuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthAssessment.Models.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthAssessment.Models.Form", b =>
                {
                    b.HasOne("HealthAssessment.Models.UserForm", null)
                        .WithMany("Forms")
                        .HasForeignKey("UserFormId");
                });

            modelBuilder.Entity("HealthAssessment.Models.UserFormResult", b =>
                {
                    b.HasOne("HealthAssessment.Models.Form", "Form")
                        .WithMany("UserFormResult")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthAssessment.Models.Question", "Question")
                        .WithMany("UserFormResult")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthAssessment.Models.User", "User")
                        .WithMany("UserFormResult")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserUserForm", b =>
                {
                    b.HasOne("HealthAssessment.Models.UserForm", null)
                        .WithMany()
                        .HasForeignKey("UserFormsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthAssessment.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthAssessment.Models.Form", b =>
                {
                    b.Navigation("UserFormResult");
                });

            modelBuilder.Entity("HealthAssessment.Models.Question", b =>
                {
                    b.Navigation("UserFormResult");
                });

            modelBuilder.Entity("HealthAssessment.Models.User", b =>
                {
                    b.Navigation("UserFormResult");
                });

            modelBuilder.Entity("HealthAssessment.Models.UserForm", b =>
                {
                    b.Navigation("Forms");
                });
#pragma warning restore 612, 618
        }
    }
}
