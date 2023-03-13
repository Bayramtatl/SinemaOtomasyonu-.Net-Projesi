using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinemaOtomasyonu.Migrations
{
    public partial class _1000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VizyonaGiris = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VizyondanCikis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fragman = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuncelleyenKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuncelleyenKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gunler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    Maas = table.Column<int>(type: "int", nullable: false),
                    UyelikTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UyelikOnayi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UcretsizIzleme = table.Column<bool>(type: "bit", nullable: true),
                    MusteriId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuncelleyenKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musteriler_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Raporlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kapsami = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Turu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GiseSatis = table.Column<int>(type: "int", nullable: false),
                    InternetSatis = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuncelleyenKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raporlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuncelleyenKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salonlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yetkililer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YetkiliTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuncelleyenKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetkililer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seanslar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeansNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Saat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilmId = table.Column<int>(type: "int", nullable: true),
                    SalonId = table.Column<int>(type: "int", nullable: true),
                    GunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seanslar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seanslar_Filmler_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seanslar_Gunler_GunId",
                        column: x => x.GunId,
                        principalTable: "Gunler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seanslar_Salonlar_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salonlar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Koltuklar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KoltukNo = table.Column<int>(type: "int", nullable: false),
                    BosMu = table.Column<bool>(type: "bit", nullable: false),
                    SeansId = table.Column<int>(type: "int", nullable: true),
                    BiletId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuncelleyenKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koltuklar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Koltuklar_Seanslar_SeansId",
                        column: x => x.SeansId,
                        principalTable: "Seanslar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Biletler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiletDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false),
                    SeansId = table.Column<int>(type: "int", nullable: true),
                    MusteriId = table.Column<int>(type: "int", nullable: true),
                    KoltukId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuncelleyenKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biletler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biletler_Koltuklar_KoltukId",
                        column: x => x.KoltukId,
                        principalTable: "Koltuklar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Biletler_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Biletler_Seanslar_SeansId",
                        column: x => x.SeansId,
                        principalTable: "Seanslar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biletler_KoltukId",
                table: "Biletler",
                column: "KoltukId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Biletler_MusteriId",
                table: "Biletler",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Biletler_SeansId",
                table: "Biletler",
                column: "SeansId");

            migrationBuilder.CreateIndex(
                name: "IX_Koltuklar_SeansId",
                table: "Koltuklar",
                column: "SeansId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_MusteriId",
                table: "Musteriler",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Seanslar_FilmId",
                table: "Seanslar",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Seanslar_GunId",
                table: "Seanslar",
                column: "GunId");

            migrationBuilder.CreateIndex(
                name: "IX_Seanslar_SalonId",
                table: "Seanslar",
                column: "SalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biletler");

            migrationBuilder.DropTable(
                name: "Raporlar");

            migrationBuilder.DropTable(
                name: "Yetkililer");

            migrationBuilder.DropTable(
                name: "Koltuklar");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Seanslar");

            migrationBuilder.DropTable(
                name: "Filmler");

            migrationBuilder.DropTable(
                name: "Gunler");

            migrationBuilder.DropTable(
                name: "Salonlar");
        }
    }
}
