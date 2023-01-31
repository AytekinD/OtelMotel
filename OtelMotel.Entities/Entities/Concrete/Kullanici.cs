﻿using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class Kullanici : BaseEntity
    {

        public Kullanici()
        {

            Roller = new HashSet<KullaniciRole>();
            Musteriler = new HashSet<Musteri>();
            Odalar = new HashSet<Oda>();
            OdaFiyatlari = new HashSet<OdaFiyat>();
            Rezervasyonlar = new HashSet<Rezervasyon>();
            RezervasyonDetaylari = new HashSet<RezervasyonDetay>();
        }
        public string? KullaniciAdi { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? TcNo { get; set; }

        public string? Adi { get; set; }
        public string? Soyadi { get; set; }

        public bool? Cinsiyet { get; set; }
        public DateTime? DogumTarihi { get; set; }

        public byte[]? ImageData { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<KullaniciRole> Roller { get; set; }
        public ICollection<Musteri> Musteriler { get; set; }
        public ICollection<Oda> Odalar { get; set; }
        public ICollection<OdaFiyat> OdaFiyatlari { get; set; }
        public ICollection<Rezervasyon> Rezervasyonlar { get; set; }
        public ICollection<RezervasyonDetay> RezervasyonDetaylari { get; set; }
    }
}
