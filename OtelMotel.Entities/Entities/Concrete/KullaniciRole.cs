using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class KullaniciRole : BaseEntity
    {
        public Guid KullaniciId { get; set; }
        public Guid RoleId { get; set; }

        public Kullanici Kullanici { get; set; }
        public Role Role { get; set; }
    }
}
