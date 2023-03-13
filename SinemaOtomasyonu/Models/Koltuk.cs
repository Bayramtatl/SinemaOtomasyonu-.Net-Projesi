using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SinemaOtomasyonu.Models
{
    public class Koltuk : BaseObject
    {
        [DisplayName("Koltuk Numarası")]
        [Required]
        [Range(1,10, ErrorMessage ="Koltuk numarası 1 ile 10 arasında olmalıdır")]
        public int KoltukNo { get; set; }

        [DisplayName("Koltuk Bilgisi")]
        [Required]
        public bool BosMu { get; set; }

        public int? SeansId { get; set; }
        public Seans? Seans { get; set; }

        public int BiletId { get; set; }
        public Bilet? Bilet { get; set; }
    }
}
