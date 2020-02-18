using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
namespace EmlakProjesi.Models
{
    public partial class EmlakDbContext : DbContext
    {
        public EmlakDbContext()
        {
        }

        public EmlakDbContext(DbContextOptions<EmlakDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Isyeri> Isyeri { get; set; }
        public virtual DbSet<Konut> Konut { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Isyeri>(entity =>
            {
                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsletmeAdi)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturmaTarihi)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Konut>(entity =>
            {
                entity.Property(e => e.EmlakTuru)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IsinmaTuru)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturmaTarihi)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Isyeri)
                    .WithMany(p => p.Konut)
                    .HasForeignKey(d => d.IsyeriId)
                    .HasConstraintName("FK_Isyeri");

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.Konut)
                    .HasForeignKey(d => d.MusteriId)
                    .HasConstraintName("FK_Musteri");
            });

            modelBuilder.Entity<Musteri>(entity =>
            {
                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Isim)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SoyIsim)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
