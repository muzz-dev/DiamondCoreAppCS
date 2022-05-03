using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiamondCoreAppCS.Models
{
    public partial class CollegeDBContext : DbContext
    {
        public CollegeDBContext()
        {
        }

        public CollegeDBContext(DbContextOptions<CollegeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diamond> Diamond { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MUZZ-PC\\SQLEXPRESS;Initial Catalog=CollegeDB;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diamond>(entity =>
            {
                entity.Property(e => e.DiamondId).HasColumnName("diamondId");

                entity.Property(e => e.DiamondCarat)
                    .HasColumnName("diamondCarat")
                    .HasColumnType("text");

                entity.Property(e => e.DiamondClarity)
                    .HasColumnName("diamondClarity")
                    .HasColumnType("text");

                entity.Property(e => e.DiamondColor)
                    .HasColumnName("diamondColor")
                    .HasColumnType("text");

                entity.Property(e => e.DiamondCut)
                    .HasColumnName("diamondCut")
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
