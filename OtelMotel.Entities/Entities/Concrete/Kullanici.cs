using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class Kullanici : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string TcNo { get; set; }
        public ICollection<Musteri> Musteriler { get; set; }
        public ICollection<Oda> Odalar { get; set; }
        public ICollection<OdaFiyat> OdaFiyatlari { get; set; }
        public ICollection<Rezervasyon> Rezervasyonlar { get; set; }
        public ICollection<RezervasyonDetay> RezervasyonDetaylari { get; set; }
    }
}
