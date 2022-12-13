﻿using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class OdaFiyat : BaseEntity
    {
        public Guid OdaId { get; set; }
        public Oda Oda { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public float Fiyat { get; set; }
        public ICollection<Rezervasyon> Rezervasyonlari { get; set; }
        public Guid KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

    }
}
