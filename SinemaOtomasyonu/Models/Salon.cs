namespace SinemaOtomasyonu.Models
{
    public class Salon:BaseObject
    {
        public string? SalonAdi { get; set; }
        public ICollection<Seans>? Seans { get; set; }

    }
}
