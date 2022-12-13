using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class Rezervasyon : BaseEntity
    {
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public Guid MusteriId { get; set; }
        public Guid OdaFiyatId { get; set; }
        public Guid OdaId { get; set; }

    }
}
