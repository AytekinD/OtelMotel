using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class Rezervasyon : BaseEntity
    {
        //Hangi odaya rezervasyon yapildi
        public Guid OdaId { get; set; }
        public Oda Oda { get; set; }
        //Odanin o tarihteki Fiyatinedir
        public Guid OdaFiyatId { get; set; }
        public OdaFiyat OdaFiyat { get; set; }
        //Odaya giris ve cikis Tarihleri
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }

        public ICollection<RezervasyonDetay> RezervasyonDetaylari { get; set; }
        public Guid KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
