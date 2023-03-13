using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SinemaOtomasyonu.Models
{
    public class Musteri : BaseObject
    {
        public Musteri()
        {
            AktifMi = true;
            OlusturanKisi = "Musteri";
            GuncelleyenKisi = "Musteri";
            OlusturmaTarihi = DateTime.Now;
            GuncellenmeTarihi = DateTime.Now;
        }


        [DisplayName("Kullanıcı Adı")]
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string? KullaniciAdi { get; set; }

        [DisplayName("Şifre")]
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [MinLength(2)]
        public string? Sifre { get; set; }

        [DisplayName("Yaş")]
        [Required]
        [Range(5, 150, ErrorMessage = "{0} {1} ile {2} arasında olmalıdır.")]
        public int Yas { get; set; }

        [DisplayName("Cinsiyet")]
        [Required]
        public bool? Cinsiyet { get; set; }

        [DisplayName("Maas")]
        [Required]
        [Range(5500, int.MaxValue, ErrorMessage = "{0} {1} ile {2} arasında olmalıdır.")]
        public int? Maas { get; set; }

        [DisplayName("Üyelik Tipi")]
        [Required]
        public string? UyelikTipi { get; set; }

        [DisplayName("Üyelik Onayı")]

        public string? UyelikOnayi { get; set; }

        [DisplayName("Ücretsiz izleme Hakkı")]

        public bool? UcretsizIzleme { get; set; }

        [DisplayName("Misafir Müşteri")]
        [Range(0, 2, ErrorMessage = "Misafir Müşteriniz 0 ve 2 arasında olabilir")]
        public List<Musteri>? MisafirMusteri { get; set; }

        public ICollection<Bilet>? Bilet { get; set; }
    }
}
