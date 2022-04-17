﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskTrackerApp.Models;

#nullable disable

namespace TaskTrackerApp.Migrations
{
    [DbContext(typeof(TrackerDbContext))]
    partial class TrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaskTrackerApp.Models.PerformersList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("IdTask")
                        .HasColumnType("bigint")
                        .HasColumnName("idTask");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.HasKey("Id");

                    b.HasIndex("IdTask");

                    b.HasIndex("IdUser");

                    b.ToTable("PerformersList", (string)null);
                });

            modelBuilder.Entity("TaskTrackerApp.Models.Section", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Section", (string)null);
                });

            modelBuilder.Entity("TaskTrackerApp.Models.Subtask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("ActualExecutionTime")
                        .HasColumnType("datetime")
                        .HasColumnName("actualExecutionTime");

                    b.Property<DateTime?>("DateCompletion")
                        .HasColumnType("datetime")
                        .HasColumnName("dateCompletion");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("date")
                        .HasColumnName("dateRegister");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<byte>("IdStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("idStatus");

                    b.Property<long>("IdTask")
                        .HasColumnType("bigint")
                        .HasColumnName("idTask");

                    b.Property<int>("Laboriousness")
                        .HasColumnType("int")
                        .HasColumnName("laboriousness");

                    b.Property<DateTime>("PeriodExecution")
                        .HasColumnType("datetime")
                        .HasColumnName("periodExecution");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("IdStatus");

                    b.HasIndex("IdTask");

                    b.ToTable("Subtask", (string)null);
                });

            modelBuilder.Entity("TaskTrackerApp.Models.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("ActualExecutionTime")
                        .HasColumnType("datetime")
                        .HasColumnName("actualExecutionTime");

                    b.Property<DateTime?>("DateCompletion")
                        .HasColumnType("datetime")
                        .HasColumnName("dateCompletion");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime")
                        .HasColumnName("dateRegister");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<long>("IdSection")
                        .HasColumnType("bigint")
                        .HasColumnName("idSection");

                    b.Property<byte>("IdStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("idStatus");

                    b.Property<int>("Laboriousness")
                        .HasColumnType("int")
                        .HasColumnName("laboriousness");

                    b.Property<DateTime>("PeriodExecution")
                        .HasColumnType("datetime")
                        .HasColumnName("periodExecution");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("IdSection");

                    b.HasIndex("IdStatus");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("TaskTrackerApp.Models.TaskStatus", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"), 1L, 1);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("TaskStatus", (string)null);
                });

            modelBuilder.Entity("TaskTrackerApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("TaskTrackerApp.Models.PerformersList", b =>
                {
                    b.HasOne("TaskTrackerApp.Models.Task", "IdTaskNavigation")
                        .WithMany("PerformersLists")
                        .HasForeignKey("IdTask")
                        .IsRequired()
                        .HasConstraintName("FK_PerformersList_Task");

                    b.HasOne("TaskTrackerApp.Models.User", "IdUserNavigation")
                        .WithMany("PerformersLists")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_PerformersList_User");

                    b.Navigation("IdTaskNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("TaskTrackerApp.Models.Section", b =>
                {
                    b.HasOne("TaskTrackerApp.Models.User", "IdUserNavigation")
                        .WithMany("Sections")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_Section_User");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("TaskTrackerApp.Models.Subtask", b =>
                {
                    b.HasOne("TaskTrackerApp.Models.TaskStatus", "IdStatusNavigation")
                        .WithMany("Subtasks")
                        .HasForeignKey("IdStatus")
                        .IsRequired()
                        .HasConstraintName("FK_Subtask_TaskStatus");

                    b.HasOne("TaskTrackerApp.Models.Task", "IdTaskNavigation")
                        .WithMany("Subtasks")
                        .HasForeignKey("IdTask")
                        .IsRequired()
                        .HasConstraintName("FK_Subtask_Task");

                    b.Navigation("IdStatusNavigation");

                    b.Navigation("IdTaskNavigation");
                });

            modelBuilder.Entity("TaskTrackerApp.Models.Task", b =>
                {
                    b.HasOne("TaskTrackerApp.Models.Section", "IdSectionNavigation")
                        .WithMany("Tasks")
                        .HasForeignKey("IdSection")
                        .IsRequired()
                        .HasConstraintName("FK_Task_Section");

                    b.HasOne("TaskTrackerApp.Models.TaskStatus", "IdStatusNavigation")
                        .WithMany("Tasks")
                        .HasForeignKey("IdStatus")
                        .IsRequired()
                        .HasConstraintName("FK_Task_TaskStatus");

                    b.Navigation("IdSectionNavigation");

                    b.Navigation("IdStatusNavigation");
                });

            modelBuilder.Entity("TaskTrackerApp.Models.Section", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskTrackerApp.Models.Task", b =>
                {
                    b.Navigation("PerformersLists");

                    b.Navigation("Subtasks");
                });

            modelBuilder.Entity("TaskTrackerApp.Models.TaskStatus", b =>
                {
                    b.Navigation("Subtasks");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskTrackerApp.Models.User", b =>
                {
                    b.Navigation("PerformersLists");

                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}