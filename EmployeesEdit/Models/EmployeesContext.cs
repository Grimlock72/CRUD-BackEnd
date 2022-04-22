﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeesEdit.Models
{
    public partial class EmployeesContext : DbContext
    {
        public EmployeesContext()
        {
        }

        public EmployeesContext(DbContextOptions<EmployeesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblProfile> TblProfiles { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1430; Database=Employees; user=sa; password=Song0ledio.;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblProfile>(entity =>
            {
                entity.HasKey(e => e.IdProfile)
                    .HasName("PK__Tbl_Prof__120435C151EDBCE5");

                entity.ToTable("Tbl_Profiles");

                entity.Property(e => e.Profile)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Tbl_User__B7C92638E5EBE155");

                entity.ToTable("Tbl_Users");

                entity.Property(e => e.CreateDate)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.IdEmployee)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.UserName)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tbl_Users__IdPro__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
