
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using JustinRESTAPISQLServerEFDemo.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace JustinRESTAPISQLServerEFDemo.Models
{
    public partial class JustinDemoContext : DbContext
    {
        public JustinDemoContext()
        {
        }

        public JustinDemoContext(DbContextOptions<JustinDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pipelines> Pipelines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.\\SQLEXPRESSGPAN; database=JustinDemo; Persist Security Info=True; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pipelines>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Length).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LicenseNumber).HasMaxLength(50);

                entity.Property(e => e.LineId)
                    .HasColumnName("LineID")
                    .HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Operator).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
