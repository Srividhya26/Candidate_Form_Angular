using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FeedbackDAL.Model;

#nullable disable

namespace FeedbackDAL.Data
{
    public partial class FeedbackContext : DbContext
    {
        public FeedbackContext()
        {
        }

        public FeedbackContext(DbContextOptions<FeedbackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<FeedbackDetail> FeedbackDetails { get; set; }
        public virtual DbSet<FeedbackDetailType> FeedbackDetailTypes { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Trainee-04;Database=Feedback;User Id=SA;Password=Srividhya@2000");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.MobileNumber).IsUnicode(false);

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__Sessio__2C3393D0");
            });

            modelBuilder.Entity<FeedbackDetail>(entity =>
            {
                entity.HasOne(d => d.Fdt)
                    .WithMany()
                    .HasForeignKey(d => d.FdtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeedbackD__FdtId__2F10007B");

                entity.HasOne(d => d.Feedback)
                    .WithMany()
                    .HasForeignKey(d => d.FeedbackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeedbackD__Feedb__2E1BDC42");
            });

            modelBuilder.Entity<FeedbackDetailType>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.SessionName).IsUnicode(false);

                entity.HasOne(d => d.Conductor)
                    .WithMany(p => p.SessionConductors)
                    .HasForeignKey(d => d.ConductorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Session__Conduct__267ABA7A");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.SessionSpeakers)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Session__Speaker__276EDEB3");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
