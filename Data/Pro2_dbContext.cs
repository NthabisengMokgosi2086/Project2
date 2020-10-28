using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project2.Models;

namespace Project2.Data
{
    public partial class Pro2_dbContext : DbContext
    {
        public Pro2_dbContext()
        {
        }

        public Pro2_dbContext(DbContextOptions<Pro2_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Models.AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<Models.AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<Models.AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<Models.AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<Models.AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<Models.AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Models.AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Models.Sheet1> Sheet1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Initial Catalog=Pro2_db;Data Source=DESKTOP-6SB3MOH\\SQLEXPRESS;Trusted_Connection=true");
            }
#pragma warning disable
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Models.AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Models.AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Models.AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Models.AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Models.AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Models.AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Models.Sheet1>(entity =>
            {
                entity.HasKey(x=>x.EmployeeNumber);

                entity.ToTable("Sheet1$");

                entity.Property(e => e.Attrition).HasMaxLength(255);

                entity.Property(e => e.BusinessTravel).HasMaxLength(255);

                entity.Property(e => e.Department).HasMaxLength(255);

                entity.Property(e => e.EducationField).HasMaxLength(255);

                entity.Property(e => e.Gender).HasMaxLength(255);

                entity.Property(e => e.JobRole).HasMaxLength(255);

                entity.Property(e => e.MaritalStatus).HasMaxLength(255);

                entity.Property(e => e.Over18).HasMaxLength(255);

                entity.Property(e => e.OverTime).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
