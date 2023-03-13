using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SinemaOtomasyonu.Models
{
    public class Film : BaseObject
    {
        public Film()
        {
            Seans = new List<Seans>();
        }

        [DisplayName("Film Adı")]
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string FilmAdi { get; set; }

        [DisplayName("Vizyona Giriş Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? VizyonaGiris { get; set; }

        [DisplayName("Vizyondan Çıkış Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? VizyondanCikis { get; set; }

        public string? Fragman { get; set; }

        public ICollection<Seans>? Seans { get; set; }

    }
}