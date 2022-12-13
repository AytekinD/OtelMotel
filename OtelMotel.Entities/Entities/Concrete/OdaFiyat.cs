using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class OdaFiyat : BaseEntity
    {
        public Guid OdaId { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public float Fiyat { get; set; }

    }
}
