using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_111_C.Models
{
    public partial class TokoBukuContext : DbContext
    {
        public TokoBukuContext()
        {
        }

        public TokoBukuContext(DbContextOptions<TokoBukuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Konsuman> Konsumen { get; set; }
        public virtual DbSet<Produk> Produks { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Admin");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Konsuman>(entity =>
            {
                entity.HasKey(e => e.IdKonsumen);

                entity.Property(e => e.IdKonsumen)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Konsumen");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelpon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("No_Telpon");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.HasKey(e => e.IdProduk);

                entity.ToTable("Produk");

                entity.Property(e => e.IdProduk)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Produk");

                entity.Property(e => e.Harga)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaProduk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Produk");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Transaksi");

                entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");

                entity.Property(e => e.IdKonsumen).HasColumnName("ID_Konsumen");

                entity.Property(e => e.IdProduk).HasColumnName("ID_Produk");

                entity.Property(e => e.TotalBiaya)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Total_Biaya");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Transaksi_Admin");

                entity.HasOne(d => d.IdKonsumenNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdKonsumen)
                    .HasConstraintName("FK_Transaksi_Konsumen");

                entity.HasOne(d => d.IdProdukNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdProduk)
                    .HasConstraintName("FK_Transaksi_Produk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
