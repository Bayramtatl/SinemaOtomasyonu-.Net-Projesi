using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SinemaOtomasyonu.Models;

namespace SinemaOtomasyonu.Controllers
{
    public class YetkiliController : Controller
    {
        public List<Film> gununFilmleri = new List<Film>();
        private DataContext context;
        public YetkiliController(DataContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult YetkiliGiris()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Giris2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YetkiliGiris(Yetkili y)
        {
            try
            {
                Yetkili y1 = context.Yetkililer.FirstOrDefault(i => i.KullaniciAdi == y.KullaniciAdi && i.Sifre == y.Sifre);
                if (y1 != null)
                {
                    HttpContext.Session.SetObjectAsJson("Yetkili", y1);
                    return RedirectToAction("Sayfa", "Yetkili");
                }

            }
            catch (Exception)
            {
                ViewBag.Hata = "Kayıt Sırasında Hata Oluştu";
            }
            return RedirectToAction("YetkiliGiris", "Yetkili");

        }
        public IActionResult Sayfa()
        {
            var yetkiliSession = HttpContext.Session.GetObjectFromJson<Yetkili>("Yetkili");
            ViewBag.Baslik = "Hoşgeldiniz"+"  "+ yetkiliSession.KullaniciAdi;
            return View();
        }

        [HttpGet]
        public IActionResult Gunler()
        {
            @ViewBag.Baslik = "Gün   Ekle - Sil İşlemleri";
            ViewBag.Gunler = context.Gunler;
            return View();
        }

        [HttpGet]
        public IActionResult GunEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GunEkle(Gun g)
        {
            if (ModelState.IsValid)
            {
                Gun g1 = new Gun();
                g1.Tarih = g.Tarih;
                context.Gunler.Add(g1);
                context.SaveChanges();
                return RedirectToAction("Gunler", "Yetkili");
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult FilmEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FilmEkle(Film film)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DateTime dt = new DateTime(2022, 8, 23,9, 0,0,0);
                    DateTime dt2 = new DateTime(2022, 8, 23, 12, 0, 0, 0);
                    DateTime dt3 = new DateTime(2022, 8, 23, 15, 0, 0, 0);
                    film.Seans.Add(new()
                    {
                        SeansNo = "Seans 1",                
                        Saat = dt,
                        Film = film
                    });
                    film.Seans.Add(new()
                    {
                        SeansNo = "Seans 2",
                        Saat = dt2,
                        Film = film
                    });
                    film.Seans.Add(new()
                    {
                        SeansNo = "Seans 3",
                        Saat = dt3,
                        Film = film
                    });

                    //for (int i = 0; i < 3; i++)
                    //    context.Seanslar.Add(new()
                    //    {
                    //        FilmId = film.Id,
                    //        SeansNo = $"Seans-{i}"
                    //    });
                    Film f = KoltukEkle(film);
                    context.Filmler.Add(f);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            // .include yazarak Filmlere ek olarak O filmin Gununu de çekebiliyoruz.
            //var film = context.Filmler.Include(t => t.Gun).FirstOrDefault(t => t.Id == f.GunId);

            return RedirectToAction("Sayfa", context.Gunler);
        }
        public Film KoltukEkle(Film f)
        {
            foreach(var s in f.Seans)
            {
                for(int i= 1; i < 25; i++)
                {
                    s.Koltuk.Add(new()
                    {
                        KoltukNo = i,
                        BosMu = true,
                        Seans = s,
                        Bilet = new() { BiletDurumu ="Satilik"}
                    });
                }
            }
            return f;
        }
        [HttpPost]
        public IActionResult SalonEkle(Salon sl)
        {
            
            if (sl.SalonAdi !=null)
            {
                var yetkiliSession = HttpContext.Session.GetObjectFromJson<Yetkili>("Yetkili");
                sl.AktifMi = false;
                sl.OlusturanKisi = yetkiliSession.KullaniciAdi;
                context.Salonlar.Add(sl);
                context.SaveChanges();
                return RedirectToAction("Salonlar", "Yetkili");
            }
            else
                return RedirectToAction("Salonlar", "Yetkili");
        }
        [HttpGet]
        public IActionResult SalonSil(int id)
        {
            var yetkiliSession = HttpContext.Session.GetObjectFromJson<Yetkili>("Yetkili");
            
            ViewBag.Filmler = context.Filmler;
            Salon salon = context.Salonlar.FirstOrDefault(i => i.Id == id);
            salon.GuncelleyenKisi = yetkiliSession.KullaniciAdi;
            context.Salonlar.Remove(salon);
            context.SaveChanges();
            return RedirectToAction("Salonlar");
        }
        [HttpGet]
        public IActionResult SalonDuzenle(int id)
        {
            Salon salon = context.Salonlar.FirstOrDefault(i => i.Id == id);
            return View(salon);
        }
        [HttpPost]
        public IActionResult SalonDuzenle(Salon sl)
        {
            var yetkiliSession = HttpContext.Session.GetObjectFromJson<Yetkili>("Yetkili");
            var varMi = context.Seanslar.FirstOrDefault(i => i.SalonId == sl.Id);
            if(varMi == null)
            {
                sl.AktifMi = false;
            }
            sl.GuncellenmeTarihi = DateTime.Now;
            sl.GuncelleyenKisi = yetkiliSession.KullaniciAdi;
            context.Salonlar.Update(sl);
            context.SaveChanges();
            return RedirectToAction("Salonlar");
        }
        [HttpGet]
        public IActionResult Salonlar()
        {
            @ViewBag.Baslik = "Salon   Ekle - Sil İşlemleri";
            ViewBag.Salonlar = context.Salonlar;
            return View();
        }

        [HttpGet]
        public IActionResult FilmSil(int f)// Hatalı
        {
            var seans = context.Seanslar.Where(i => i.FilmId == f).ToList();
            context.RemoveRange(seans);
            context.SaveChanges();
            context.Remove(f);
            context.SaveChanges();
            return RedirectToAction("FilmList", "Yetkili");
        }

        [HttpGet]
        public IActionResult FilmList()
        {
            @ViewBag.Baslik = "Vizyondaki Filmler";
            var dc = context.Seanslar.ToList();
            foreach (var seans in dc)
            {
                Film f = context.Filmler.FirstOrDefault(i => i.Id == seans.FilmId);
                if (gununFilmleri.Count == 0)
                {
                    gununFilmleri.Add(f);
                }
                if (!gununFilmleri.Contains(f))
                {
                    gununFilmleri.Add(f);
                }
            }
            ViewBag.filmler = gununFilmleri;
            return View(context.Gunler);
        }

        [HttpGet]
        public IActionResult Listele(int id) // Gün Seçimine göre o güne ait filmleri listeleyen fonksiyon
        {
            @ViewBag.Baslik = "Günün Filmleri";
            var dc = context.Seanslar.Where(t => t.GunId == id).ToList();
            context.SaveChanges();
            foreach (var seans in dc)
            {
                Film f = context.Filmler.FirstOrDefault(i => i.Id == seans.FilmId);
                if(gununFilmleri.Count == 0)
                {
                    gununFilmleri.Add(f);
                }
                if (!gununFilmleri.Contains(f))
                {
                    gununFilmleri.Add(f);
                }
            }
            ViewBag.filmler = gununFilmleri;
            return View(context.Gunler);
        }
        [HttpGet]
        public IActionResult GunSil(int id)
        {
            var gun = new Gun() { Id = id };
            context.Remove(gun);
            context.SaveChanges();
            return RedirectToAction("Gunler", "Yetkili");
        }
        [HttpGet]
        public IActionResult Seanslar()
        {
            @ViewBag.Baslik = "Seans   Ekle - Güncelle - Sil İşlemleri";
            var dataContext = context.Seanslar.Include(s => s.Film).Include(s => s.Salon).Include(t => t.Gun);
            return View(dataContext);
        }
        [HttpGet]
        public IActionResult SeansEkle()
        {
            @ViewBag.Baslik = "Seans Ekleme Sayfası";
            ViewData["Filmler"] = new SelectList(context.Filmler, "Id", "FilmAdi");
            ViewData["Salonlar"] = new SelectList(context.Salonlar, "Id", "SalonAdi");
            ViewData["Gunler"] = new SelectList(context.Gunler, "Id", "Tarih");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SeansEkle(Seans seans)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < 23; i++) {
                    seans.Koltuk.Add(new()
                    {
                        KoltukNo = i + 1,
                        BosMu = true,
                        Seans = seans,
                        Bilet = new() { BiletDurumu = "Satilik"},
                    });
                }
                context.Add(seans);
                await context.SaveChangesAsync();
                return RedirectToAction("Seanslar");
            }
            ViewData["Filmler"] = new SelectList(context.Filmler, "Id", "FilmAdi");
            ViewData["Salonlar"] = new SelectList(context.Salonlar, "Id", "SalonAdi");
            ViewData["Gunler"] = new SelectList(context.Gunler, "Id", "Tarih");
            return View(seans);
        }
        [HttpGet]
        public async Task<IActionResult> SeansDuzenle(int? id)
        {
            @ViewBag.Baslik = "Seans Düzenleme Sayfası";
            var seans = await context.Seanslar.FindAsync(id);
            ViewData["Filmler"] = new SelectList(context.Filmler, "Id", "FilmAdi");
            ViewData["Salonlar"] = new SelectList(context.Salonlar, "Id", "SalonAdi");
            ViewData["Gunler"] = new SelectList(context.Gunler, "Id", "Tarih");
            ViewBag.Koltuklar = context.Koltuklar.Where(i=> i.SeansId == id);
            return View(seans);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SeansDuzenle(int id, [Bind("Id,SalonId,FilmId,GunId,Saat")] Seans seans)
        {
            if (ModelState.IsValid)
            {
                context.Update(seans);
                await context.SaveChangesAsync();
                var dataContext = context.Seanslar.Include(s => s.Film).Include(s => s.Salon).Include(t => t.Salon);
                return RedirectToAction("Seanslar","Yetkili",dataContext);
            }
            ViewData["Filmler"] = new SelectList(context.Filmler, "Id", "FilmAdi");
            ViewData["Salonlar"] = new SelectList(context.Salonlar, "Id", "SalonAdi");
            ViewData["Gunler"] = new SelectList(context.Gunler, "Id", "Tarih");
            return View(seans);
        }
        [HttpGet]
        public IActionResult SeansSil(int id)
        {
            List<Koltuk> k = context.Koltuklar.Where(i => i.SeansId == id).ToList();
            context.RemoveRange(k);
            context.SaveChanges();
            Seans seans = context.Seanslar.Include(t=> t.Koltuk).FirstOrDefault(i => i.Id == id);
            context.Remove(seans);
            context.SaveChanges();
            return RedirectToAction("Seanslar");
        }
        [HttpGet]
        public IActionResult RezervasyonList()
        {
            @ViewBag.Baslik = "Müşteri Rezervasyonu İşlemleri";
            return View(context.Biletler.Where(i=> i.BiletDurumu == "Onay Bekliyor").Include(i=> i.Musteri).Include(i => i.Koltuk).Include(i => i.Seans));
        }

        public IActionResult BiletOnay(int id)// Yetkili tarafından biletlerin onaylanmasını sağlayan fonksiyon
        {
            var bilet = context.Biletler.FirstOrDefault(i => i.Id == id);
            bilet.BiletDurumu = "Rezerve Edildi";
            context.Update(bilet);
            context.SaveChanges();
            return RedirectToAction("RezervasyonList");

        }
    }
}