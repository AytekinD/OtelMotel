using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.Entities.Entities.Concrete
{
    public class Kullanici : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
