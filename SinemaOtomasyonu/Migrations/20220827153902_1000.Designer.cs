﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SinemaOtomasyonu;

#nullable disable

namespace SinemaOtomasyonu.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220827153902_1000")]
    partial class _1000
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SinemaOtomasyonu.Models.Bilet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("BiletDurumu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fiyat")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuncelleyenKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KoltukId")
                        .HasColumnType("int");

                    b.Property<int?>("MusteriId")
                        .HasColumnType("int");

                    b.Property<string>("OlusturanKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OlusturmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SeansId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KoltukId")
                        .IsUnique();

                    b.HasIndex("MusteriId");

                    b.HasIndex("SeansId");

                    b.ToTable("Biletler");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("FilmAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Fragman")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuncelleyenKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OlusturanKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OlusturmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("VizyonaGiris")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("VizyondanCikis")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Filmler");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Gun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuncelleyenKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OlusturanKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OlusturmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Gunler");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Koltuk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<int>("BiletId")
                        .HasColumnType("int");

                    b.Property<bool>("BosMu")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuncelleyenKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KoltukNo")
                        .HasColumnType("int");

                    b.Property<string>("OlusturanKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OlusturmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SeansId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeansId");

                    b.ToTable("Koltuklar");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Musteri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<bool?>("Cinsiyet")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuncelleyenKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Maas")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MusteriId")
                        .HasColumnType("int");

                    b.Property<string>("OlusturanKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OlusturmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("UcretsizIzleme")
                        .HasColumnType("bit");

                    b.Property<string>("UyelikOnayi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UyelikTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Yas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MusteriId");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Rapor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<int>("GiseSatis")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuncelleyenKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InternetSatis")
                        .HasColumnType("int");

                    b.Property<string>("Kapsami")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OlusturanKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OlusturmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Turu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Raporlar");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuncelleyenKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OlusturanKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OlusturmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("SalonAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Salonlar");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Seans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<int?>("GunId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Saat")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SalonId")
                        .HasColumnType("int");

                    b.Property<string>("SeansNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("GunId");

                    b.HasIndex("SalonId");

                    b.ToTable("Seanslar");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Yetkili", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuncelleyenKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OlusturanKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OlusturmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("YetkiliTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Yetkililer");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Bilet", b =>
                {
                    b.HasOne("SinemaOtomasyonu.Models.Koltuk", "Koltuk")
                        .WithOne("Bilet")
                        .HasForeignKey("SinemaOtomasyonu.Models.Bilet", "KoltukId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SinemaOtomasyonu.Models.Musteri", "Musteri")
                        .WithMany("Bilet")
                        .HasForeignKey("MusteriId");

                    b.HasOne("SinemaOtomasyonu.Models.Seans", "Seans")
                        .WithMany()
                        .HasForeignKey("SeansId");

                    b.Navigation("Koltuk");

                    b.Navigation("Musteri");

                    b.Navigation("Seans");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Koltuk", b =>
                {
                    b.HasOne("SinemaOtomasyonu.Models.Seans", "Seans")
                        .WithMany("Koltuk")
                        .HasForeignKey("SeansId");

                    b.Navigation("Seans");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Musteri", b =>
                {
                    b.HasOne("SinemaOtomasyonu.Models.Musteri", null)
                        .WithMany("MisafirMusteri")
                        .HasForeignKey("MusteriId");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Seans", b =>
                {
                    b.HasOne("SinemaOtomasyonu.Models.Film", "Film")
                        .WithMany("Seans")
                        .HasForeignKey("FilmId");

                    b.HasOne("SinemaOtomasyonu.Models.Gun", "Gun")
                        .WithMany("Seans")
                        .HasForeignKey("GunId");

                    b.HasOne("SinemaOtomasyonu.Models.Salon", "Salon")
                        .WithMany("Seans")
                        .HasForeignKey("SalonId");

                    b.Navigation("Film");

                    b.Navigation("Gun");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Film", b =>
                {
                    b.Navigation("Seans");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Gun", b =>
                {
                    b.Navigation("Seans");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Koltuk", b =>
                {
                    b.Navigation("Bilet");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Musteri", b =>
                {
                    b.Navigation("Bilet");

                    b.Navigation("MisafirMusteri");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Salon", b =>
                {
                    b.Navigation("Seans");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.Seans", b =>
                {
                    b.Navigation("Koltuk");
                });
#pragma warning restore 612, 618
        }
    }
}
