using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RCPartPickerAPI.Models
{
    public partial class PartPickerDBContext : DbContext
    {
        public PartPickerDBContext()
        {
        }

        public PartPickerDBContext(DbContextOptions<PartPickerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<PartCategory> PartCategory { get; set; }
        public virtual DbSet<PartPartProperty> PartPartProperty { get; set; }
        public virtual DbSet<PartProperty> PartProperty { get; set; }
        public virtual DbSet<PartPropertyGroup> PartPropertyGroup { get; set; }
        public virtual DbSet<PartSubcategory> PartSubcategory { get; set; }
        public virtual DbSet<RCCategory> RCCategory { get; set; }
        public virtual DbSet<RCSubcategory> RCSubcategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PartPickerDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PartSubcategory)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.PartSubcategoryId)
                    .HasConstraintName("FK_Part_PartSubcategory");
            });

            modelBuilder.Entity<PartCategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartPartProperty>(entity =>
            {
                entity.ToTable("Part_PartProperty");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.PartPartProperty)
                    .HasForeignKey(d => d.PartId)
                    .HasConstraintName("FK_Part_PartProperty_Part");

                entity.HasOne(d => d.PartProperty)
                    .WithMany(p => p.PartPartProperty)
                    .HasForeignKey(d => d.PartPropertyId)
                    .HasConstraintName("FK_Part_PartProperty_PartProperty");
            });

            modelBuilder.Entity<PartProperty>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PartPropertyGroup)
                    .WithMany(p => p.PartProperty)
                    .HasForeignKey(d => d.PartPropertyGroupId)
                    .HasConstraintName("FK_PartProperty_PartPropertyGroup");
            });

            modelBuilder.Entity<PartPropertyGroup>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartSubcategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PartCategory)
                    .WithMany(p => p.PartSubcategory)
                    .HasForeignKey(d => d.PartCategoryId)
                    .HasConstraintName("FK_PartSubcategory_PartCategory");
            });

            modelBuilder.Entity<RCCategory>(entity =>
            {
                entity.ToTable("RCCategory");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RCSubcategory>(entity =>
            {
                entity.ToTable("RCSubcategory");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RCCategoryId).HasColumnName("RCCategoryId");

                entity.HasOne(d => d.RCCategory)
                    .WithMany(p => p.RCSubcategory)
                    .HasForeignKey(d => d.RCCategoryId)
                    .HasConstraintName("FK_RCSubcategory_RCCategory");
            });
        }
    }
}
