using System.ComponentModel.DataAnnotations;

namespace SinemaOtomasyonu.Models
{
    public class Gun:BaseObject
    {
        public Gun()
        {
            OlusturanKisi = "Yetkili";
            OlusturmaTarihi = DateTime.Now;
            GuncellenmeTarihi = DateTime.Now;
            AktifMi = true;
            GuncelleyenKisi = "Yetkili";
        }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy H:mm:ss}")]
        public DateTime Tarih { get; set; }

        public ICollection<Seans>? Seans { get; set; }
    }
}