using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
        public ICollection<Kullanici>? Kullanicilar { get; set; }
    }
}
