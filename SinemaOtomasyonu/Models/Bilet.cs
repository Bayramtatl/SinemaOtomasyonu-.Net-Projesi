using System.ComponentModel.DataAnnotations;

namespace SinemaOtomasyonu.Models
{
    public class Bilet : BaseObject
    {
        public string BiletDurumu { get; set; }
        public int Fiyat { get; set; }

        public int? MusteriId { get; set; }
        public Musteri? Musteri { get; set; }

        public int KoltukId { get; set; }
        public Koltuk? Koltuk { get; set; }

        public int? SeansId { get; set; }
        public Seans Seans { get; set; }
    }
}
