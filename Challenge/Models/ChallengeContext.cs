using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Challenge.Models
{
    public partial class ChallengeContext : DbContext
    {
        public ChallengeContext()
        {
        }

        public ChallengeContext(DbContextOptions<ChallengeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Maintenance> Maintenance { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS ; Database=Challenge ; Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.NextMaintenanceKms).HasColumnName("NextMaintenance_kms");

                entity.Property(e => e.Patent)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PatentNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Patent)
                    .HasConstraintName("FK__Maintenan__Paten__2C3393D0");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.Patent)
                    .HasName("PK__Vehicle__B25FF4829121B16F");

                entity.Property(e => e.Patent)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChasisNumber)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Wheels)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.UrlImage)
                   .HasMaxLength(250)
                   .IsUnicode(false);

              entity.Property(e => e.UrlImage)
                  .HasMaxLength(1)
                  .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
