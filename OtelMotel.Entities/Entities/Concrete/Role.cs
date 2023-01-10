using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class Role : BaseEntity
    {
        public Role()
        {
            Kullanicilar = new HashSet<KullaniciRole>();
        }
        public string? RoleName { get; set; }

        public ICollection<KullaniciRole> Kullanicilar { get; set; }
    }
}
