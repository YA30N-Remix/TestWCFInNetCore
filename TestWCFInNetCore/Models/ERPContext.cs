using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestWCFInNetCore.Models
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminForm> AdminForms { get; set; } = null!;
        public virtual DbSet<AdminRole> AdminRoles { get; set; } = null!;
        public virtual DbSet<AdminSubSystem> AdminSubSystems { get; set; } = null!;
        public virtual DbSet<AdminUser> AdminUsers { get; set; } = null!;
        public virtual DbSet<AdminUserRole> AdminUserRoles { get; set; } = null!;
        public virtual DbSet<Carcartable> Carcartables { get; set; } = null!;
        public virtual DbSet<CarcartableTrace> CarcartableTraces { get; set; } = null!;
        public virtual DbSet<Cartable> Cartables { get; set; } = null!;
        public virtual DbSet<Empemployee> Empemployees { get; set; } = null!;
        public virtual DbSet<InOutRequestLeaf> InOutRequestLeaves { get; set; } = null!;
        public virtual DbSet<ServRequestService> ServRequestServices { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; UID=sa; Password=ABCabc123456;Database=ERP;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminForm>(entity =>
            {
                entity.HasIndex(e => e.AdminSubSystemId, "IX_AdminForms_AdminSubSystemId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FormName).HasMaxLength(100);

                entity.Property(e => e.FormNameFa).HasMaxLength(100);

                entity.HasOne(d => d.AdminSubSystem)
                    .WithMany(p => p.AdminForms)
                    .HasForeignKey(d => d.AdminSubSystemId);
            });

            modelBuilder.Entity<AdminRole>(entity =>
            {
                entity.HasIndex(e => e.RoleName, "IX_AdminRoles_RoleName")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.RoleName).HasMaxLength(100);

                entity.Property(e => e.RoleNameFa)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<AdminSubSystem>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.SubSystemName).HasMaxLength(100);

                entity.Property(e => e.SubSystemNameFarsi).HasMaxLength(100);
            });

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasIndex(e => e.EmpemployeeId, "IX_AdminUsers_EMPEmployeeId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EmpemployeeId).HasColumnName("EMPEmployeeId");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.MobileNo).HasMaxLength(11);

                entity.Property(e => e.PassWord).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.VerificationCode).HasMaxLength(100);

                entity.HasOne(d => d.Empemployee)
                    .WithMany(p => p.AdminUsers)
                    .HasForeignKey(d => d.EmpemployeeId);
            });

            modelBuilder.Entity<AdminUserRole>(entity =>
            {
                entity.HasIndex(e => e.AdminRoleId, "IX_AdminUserRoles_AdminRoleId");

                entity.HasIndex(e => e.AdminUserId, "IX_AdminUserRoles_AdminUserId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.AdminRole)
                    .WithMany(p => p.AdminUserRoles)
                    .HasForeignKey(d => d.AdminRoleId);

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.AdminUserRoles)
                    .HasForeignKey(d => d.AdminUserId);
            });

            modelBuilder.Entity<Carcartable>(entity =>
            {
                entity.ToTable("CARCartables");

                entity.HasIndex(e => e.CarcartableTraceId, "IX_CARCartables_CARCartableTraceId");

                entity.HasIndex(e => e.EmpemployeeId, "IX_CARCartables_EMPEmployeeId");

                entity.Property(e => e.CarcartableTraceId).HasColumnName("CARCartableTraceId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EmpemployeeId).HasColumnName("EMPEmployeeId");

                entity.Property(e => e.FieldCode).HasMaxLength(20);

                entity.Property(e => e.RequestDate).HasMaxLength(10);

                entity.Property(e => e.SignDate).HasMaxLength(10);

                entity.HasOne(d => d.CarcartableTrace)
                    .WithMany(p => p.Carcartables)
                    .HasForeignKey(d => d.CarcartableTraceId);

                entity.HasOne(d => d.Empemployee)
                    .WithMany(p => p.Carcartables)
                    .HasForeignKey(d => d.EmpemployeeId);
            });

            modelBuilder.Entity<CarcartableTrace>(entity =>
            {
                entity.ToTable("CARCartableTraces");

                entity.HasIndex(e => e.AdminRoleId, "IX_CARCartableTraces_AdminRoleId");

                entity.HasIndex(e => e.CartableId, "IX_CARCartableTraces_CARTableId");

                entity.Property(e => e.CartableId).HasColumnName("CARTableId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.SignTitle).HasMaxLength(100);

                entity.Property(e => e.SignTitleFa).HasMaxLength(100);

                entity.HasOne(d => d.AdminRole)
                    .WithMany(p => p.CarcartableTraces)
                    .HasForeignKey(d => d.AdminRoleId);

                entity.HasOne(d => d.Cartable)
                    .WithMany(p => p.CarcartableTraces)
                    .HasForeignKey(d => d.CartableId);
            });

            modelBuilder.Entity<Cartable>(entity =>
            {
                entity.ToTable("CARTables");

                entity.HasIndex(e => e.AdminFormId, "IX_CARTables_AdminFormId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.TableName).HasMaxLength(50);

                entity.HasOne(d => d.AdminForm)
                    .WithMany(p => p.Cartables)
                    .HasForeignKey(d => d.AdminFormId);
            });

            modelBuilder.Entity<Empemployee>(entity =>
            {
                entity.ToTable("EMPEmployees");

                entity.HasIndex(e => e.EmpoloyeeNo, "IX_EMPEmployees_EmpoloyeeNo")
                    .IsUnique();

                entity.HasIndex(e => e.NationalCode, "IX_EMPEmployees_NationalCode")
                    .IsUnique();

                entity.Property(e => e.DateOfBirth).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FatherName).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.HireDate).HasMaxLength(10);

                entity.Property(e => e.IdentifyNo).HasMaxLength(10);

                entity.Property(e => e.ImaghePath).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.LeaveDate).HasMaxLength(10);

                entity.Property(e => e.MobileNo).HasMaxLength(11);

                entity.Property(e => e.NationalCode).HasMaxLength(10);
            });

            modelBuilder.Entity<InOutRequestLeaf>(entity =>
            {
                entity.HasIndex(e => e.EmpemployeeId, "IX_InOutRequestLeaves_EMPEmployeeId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EmpemployeeId).HasColumnName("EMPEmployeeId");

                entity.Property(e => e.FromDate).HasMaxLength(10);

                entity.Property(e => e.FromTime).HasMaxLength(8);

                entity.Property(e => e.LeaveReason).HasMaxLength(250);

                entity.Property(e => e.RequestDate).HasMaxLength(10);

                entity.Property(e => e.TimeLeaveDate).HasMaxLength(10);

                entity.Property(e => e.ToDate).HasMaxLength(10);

                entity.Property(e => e.ToTime).HasMaxLength(8);

                entity.HasOne(d => d.Empemployee)
                    .WithMany(p => p.InOutRequestLeaves)
                    .HasForeignKey(d => d.EmpemployeeId);
            });

            modelBuilder.Entity<ServRequestService>(entity =>
            {
                entity.HasIndex(e => e.EmpemployeeId, "IX_ServRequestServices_EMPEmployeeId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EmpemployeeId).HasColumnName("EMPEmployeeId");

                entity.Property(e => e.RequestDate).HasMaxLength(10);

                entity.Property(e => e.ServicesOrGoods).HasMaxLength(250);

                entity.HasOne(d => d.Empemployee)
                    .WithMany(p => p.ServRequestServices)
                    .HasForeignKey(d => d.EmpemployeeId);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasIndex(e => e.AdminUserId, "IX_Sessions_AdminUserId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.SessionUser).HasMaxLength(500);

                entity.Property(e => e.Token).HasMaxLength(500);

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.AdminUserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
