using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SinemaOtomasyonu.Models
{
    public class Yetkili : BaseObject
    {
        [DisplayName("Kullanıcı Adı")]
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string? KullaniciAdi { get; set; }

        [DisplayName("Şifre")]
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [MinLength(3)]
        public string? Sifre { get; set; }

        [DisplayName("Yetkili Tipi")]
        [Required]
        public string? YetkiliTipi { get; set; }



    }
}
