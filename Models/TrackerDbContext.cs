using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskTrackerApp.Models
{
    public partial class TrackerDbContext : DbContext
    {
        public TrackerDbContext()
        {
        }

        public TrackerDbContext(DbContextOptions<TrackerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PerformersList> PerformersLists { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Subtask> Subtasks { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Service.Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerformersList>(entity =>
            {
                entity.ToTable("PerformersList");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdTask).HasColumnName("idTask");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdTaskNavigation)
                    .WithMany(p => p.PerformersLists)
                    .HasForeignKey(d => d.IdTask)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerformersList_Task");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PerformersLists)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerformersList_User");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("Section");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Section_User");
            });

            modelBuilder.Entity<Subtask>(entity =>
            {
                entity.ToTable("Subtask");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActualExecutionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("actualExecutionTime");

                entity.Property(e => e.DateCompletion)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCompletion");

                entity.Property(e => e.DateRegister)
                    .HasColumnType("date")
                    .HasColumnName("dateRegister");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.IdTask).HasColumnName("idTask");

                entity.Property(e => e.Laboriousness).HasColumnName("laboriousness");

                entity.Property(e => e.PeriodExecution)
                    .HasColumnType("datetime")
                    .HasColumnName("periodExecution");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Subtasks)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subtask_TaskStatus");

                entity.HasOne(d => d.IdTaskNavigation)
                    .WithMany(p => p.Subtasks)
                    .HasForeignKey(d => d.IdTask)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subtask_Task");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActualExecutionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("actualExecutionTime");

                entity.Property(e => e.DateCompletion)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCompletion");

                entity.Property(e => e.DateRegister)
                    .HasColumnType("datetime")
                    .HasColumnName("dateRegister");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.Laboriousness).HasColumnName("laboriousness");

                entity.Property(e => e.PeriodExecution)
                    .HasColumnType("datetime")
                    .HasColumnName("periodExecution");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdSection)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Section");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_TaskStatus");
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.ToTable("TaskStatus");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
