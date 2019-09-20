using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain;

namespace Persistence
{
    // dotnet ef dbcontext scaffold "Data Source=../../CareHome/SQLiteDB/CareHome.db" Microsoft.EntityFrameworkCore.Sqlite
    public partial class CareHomeContext : DbContext
    {
        public CareHomeContext()
        {
        }

        public CareHomeContext(DbContextOptions<CareHomeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Homes> Homes { get; set; }
        public virtual DbSet<Qualifications> Qualifications { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlite("Data Source=../../CareHome/SQLiteDB/CareHome.db");
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Homes>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Qualifications>(entity =>
            {
                entity.HasIndex(e => e.StaffId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Qualifications)
                    .HasForeignKey(d => d.StaffId);
            });

            modelBuilder.Entity<Staffs>(entity =>
            {
                entity.HasIndex(e => e.HomeId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AnnualSalary)
                    .IsRequired()
                    .HasColumnType("money");

                entity.Property(e => e.DateOfBirth).IsRequired();

                entity.Property(e => e.Forename).IsRequired();

                entity.Property(e => e.Surname).IsRequired();

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.HomeId);
            });
        }
    }
}
