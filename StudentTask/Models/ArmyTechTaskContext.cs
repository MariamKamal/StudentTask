using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentTask.Models
{
    public partial class ArmyTechTaskContext : DbContext
    {
        public ArmyTechTaskContext()
        {
        }

        public ArmyTechTaskContext(DbContextOptions<ArmyTechTaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<Governorate> Governorate { get; set; }
        public virtual DbSet<Neighborhood> Neighborhood { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentTeacher> StudentTeacher { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=ArmyTechTask;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Governorate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.Neighborhood)
                    .HasForeignKey(d => d.GovernorateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Neighborhood_Governorate");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Field");

                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.GovernorateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Governorate");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .HasConstraintName("FK_Student_Neighborhood");
            });

            modelBuilder.Entity<StudentTeacher>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTeacher)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentTeacher_Student");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.StudentTeacher)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentTeacher_Teacher");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
