using Microsoft.AspNetCore.Mvc;
using SinemaOtomasyonu.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace SinemaOtomasyonu.Controllers
{
    public class MusteriController : Controller
    {
        private DataContext context;
        List<Film> gununFilmleri = new List<Film>();
        List<Seans> Seanslarim = new List<Seans>();
        List<Gun> Gunler = new List<Gun>();
        List<Gun> Gunler2 = new List<Gun>();
        public MusteriController(DataContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Index()
        {
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
            ViewBag.Gunler = context.Gunler;
            return View(context.Gunler);
        }
        [HttpPost]
        public IActionResult KayıtOl(Musteri m1)
        {
            try
            {
                m1.UcretsizIzleme = false;
                m1.MisafirMusteri = null;

                if (!ModelState.IsValid)
                    return RedirectToAction("KayıtOl", "Home");

                context.Add(m1);
                var result = context.SaveChanges();

                if (result > 0)
                {

                    return RedirectToAction("Index", "Home", m1);
                }

                ViewBag.Hata = "Kayıt Sırasında HAta Oluştu";

            }
            catch (Exception)
            {

                ViewBag.Hata = "Kayıt Sırasında HAta Oluştu";
            }

            return RedirectToAction("KayıtOl", "Home");
        }
        [HttpPost]
        public IActionResult GirisYap(Musteri m)
        {
            try
            {
                Musteri m1 = context.Musteriler.FirstOrDefault(i => i.KullaniciAdi == m.KullaniciAdi && i.Sifre == m.Sifre);
                if (m1 != null)
                {
                    HttpContext.Session.SetObjectAsJson("Musteri", m1);
                    return RedirectToAction("Index", "Musteri");
                }

            }
            catch (Exception)
            {
                ViewBag.Hata = "Kayıt Sırasında Hata Oluştu";
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Bilgiler()
        {
            var musteri = HttpContext.Session.GetObjectFromJson<Musteri>("Musteri");

            return View();
        }
        [HttpPost]
        public IActionResult Bilgiler(Musteri m1)
        {
            var musteri = HttpContext.Session.GetObjectFromJson<Musteri>("Musteri");
            var m2 = context.Musteriler.FirstOrDefault(i => i.Id == musteri.Id);
            m2.KullaniciAdi = m1.KullaniciAdi;
            m2.Sifre = m1.Sifre;
            m2.Yas = m1.Yas;
            m2.Cinsiyet = m1.Cinsiyet;
            m2.Maas = m1.Maas;
            context.Update(m2);
            context.SaveChanges();
            return RedirectToAction("Bilgiler", "Musteri");
        }
        [HttpGet]
        public IActionResult Listele(int id, int film)
        // Bu fonksiyon değiştirelecek şöyle ki filmlerin rezervasyon işlemlerinin yapılabilmesi için o filmi veya seansı model olarak
        // göndermemiz gerekiyor ama ahli hazırda bunu yapmıyoruz.
        {
            var dc = context.Seanslar.Where(t => t.GunId == id).ToList();
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

        public IActionResult RezerveEt(int id)
        {
            var Film = context.Filmler.FirstOrDefault(i => i.Id == id);
            Seanslarim = context.Seanslar.Where(i => i.FilmId == id).Include(f => f.Film).Include(f => f.Gun).Include(f => f.Salon).ToList();
            return View(Seanslarim);
        }
        [HttpGet]
        public IActionResult BiletSayfasi(int id)// seans id //
        {
            Seans s1 = context.Seanslar.Include(f => f.Film).Include(f => f.Gun).Include(f => f.Salon).Include(f => f.Koltuk).FirstOrDefault(i => i.Id == id);
            ViewBag.Seans = s1;
            ViewBag.Fiyat = 30;
            return View();
        }
        [HttpGet]
        public IActionResult BiletOnay(int id, int koltuk)// seansid ve koltuk id
        {
            Bilet b = context.Biletler.FirstOrDefault(i=> i.KoltukId == koltuk);
            b.Koltuk = context.Koltuklar.FirstOrDefault(i=> i.Id == koltuk);
            b.Koltuk.BosMu = false;
            b.BiletDurumu = "Onay Bekliyor";
            var musteri = HttpContext.Session.GetObjectFromJson<Musteri>("Musteri");        
            b.Musteri = musteri;
            b.MusteriId = musteri.Id;
            b.AktifMi = true;
            b.Fiyat = 30;
            context.Update(b);
            context.SaveChanges();
            Koltuk k = context.Koltuklar.FirstOrDefault(context => context.Id == koltuk);
            k.BiletId = b.Id;
            k.BosMu = false;
            context.Update(k);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SatinAlmaGecmisi()
        {
            Musteri m1 = HttpContext.Session.GetObjectFromJson<Musteri>("Musteri");
            var Biletler = context.Biletler.Where(i => i.MusteriId == m1.Id).Include(t => t.Koltuk);
            return View(context.Biletler.Where(i=> i.MusteriId == m1.Id).Include(t=> t.Koltuk).Include(t => t.Seans.Film).Include(t => t.Seans.Gun));

        }
        [HttpGet]
        public IActionResult BiletIptal(int id)
        {
            Bilet b1 = context.Biletler.FirstOrDefault(i=> i.Id==id);
            b1.MusteriId= null;
            b1.Musteri = null;
            b1.BiletDurumu = "Satilik";
            context.Update(b1);
            context.SaveChanges();
            Koltuk k1 = context.Koltuklar.FirstOrDefault(i => i.BiletId == id);
            k1.BosMu = true;
            k1.Bilet = null;
            k1.BiletId = 0;
            context.Update(b1);
            context.SaveChanges();
            return RedirectToAction("SatinAlmaGecmisi");
        }
    }
}
