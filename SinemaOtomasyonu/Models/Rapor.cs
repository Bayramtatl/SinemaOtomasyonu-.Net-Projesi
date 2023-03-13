using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SinemaOtomasyonu.Models
{
    public class Rapor : BaseObject
    {

        [DisplayName("Raporun süresel kapsamı")]
        [MaxLength(50)]
        [MinLength(5)]
        public string? Kapsami { get; set; }

        [DisplayName("Raporun türü")]
        [MaxLength(50)]
        [MinLength(5)]
        public string? Turu { get; set; }

        [DisplayName("Gişe Satışı miktarı")]
        public int GiseSatis { get; set; }

        [DisplayName("İnternet Satışı miktarı")]
        public int InternetSatis { get; set; }


    }
}
