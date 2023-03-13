using SinemaOtomasyonu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SinemaOtomasyonu
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        { }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Koltuk> Koltuklar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<Yetkili> Yetkililer { get; set; }
        public DbSet<Salon> Salonlar { get; set; }
        public DbSet<Gun> Gunler { get; set; }
        public DbSet<Seans> Seanslar { get; set; }
        public DbSet<Bilet> Biletler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Koltuk>()
            .HasOne(a => a.Bilet)
            .WithOne(a => a.Koltuk)
            .HasForeignKey<Bilet>(c => c.KoltukId);
            }
    }

}