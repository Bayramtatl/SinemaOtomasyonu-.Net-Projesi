using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinemaOtomasyonu.Models
{
    public class Seans
    {
        public Seans()
        {
            Koltuk = new List<Koltuk>();
        }
            [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? SeansNo { get; set; }
        [DataType(DataType.Time)]
        public DateTime? Saat { get; set; }
        public int? FilmId { get; set; }
        public Film? Film { get; set; }

        public int? SalonId { get; set; }
        public Salon? Salon { get; set; }

        public int? GunId { get; set; }
        public Gun? Gun { get; set; }

        public ICollection<Koltuk>? Koltuk { get; set; }
    }
}
