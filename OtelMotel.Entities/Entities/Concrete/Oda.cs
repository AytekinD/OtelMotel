using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class Oda : BaseEntity
    {
        public string OdaNo { get; set; }
        public byte KisiSayisi { get; set; }
        public bool Durum { get; set; } = true;
        public ICollection<OdaFiyat> OdaFiyatlari { get; set; }
        public ICollection<Rezervasyon> Rezervasyonlari { get; set; }
    }
}
