using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Task1.Models
{
    public partial class Task1Context : DbContext
    {
        public Task1Context()
        {
        }

        public Task1Context(DbContextOptions<Task1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<DocumentData> DocumentData { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog=Task1;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentData>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.Property(e => e.DocName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocPath)
                    .HasMaxLength(80)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId).ValueGeneratedNever();

                entity.Property(e => e.EmpAdress)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Table_1");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Table_1");

                entity.ToTable("UserInfo");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
