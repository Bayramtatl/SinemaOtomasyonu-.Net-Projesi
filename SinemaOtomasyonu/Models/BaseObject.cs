using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SinemaOtomasyonu.Models
{
    public class BaseObject
    {
        public BaseObject()
        {
            OlusturmaTarihi = DateTime.Now;
            GuncellenmeTarihi = DateTime.Now;
            AktifMi = true;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Oluşturma Tarihi")]
        public DateTime? OlusturmaTarihi { get; set; }

        [DisplayName("Güncelleme Tarihi")]
        public DateTime? GuncellenmeTarihi { get; set; }

        
        [DisplayName("Oluşturan Kişi")]
        
        public string? OlusturanKisi { get; set; }

        [DisplayName("Güncelleyen Kişi")]
        
        public string? GuncelleyenKisi { get; set; }

        [DisplayName("Aktif Mi")]
        public bool AktifMi { get; set; }
            

    }
}
