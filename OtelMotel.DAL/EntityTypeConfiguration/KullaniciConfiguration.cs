using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelMotel.Entities.Entities.Concrete;

namespace OtelMotel.DAL.EntityTypeConfiguration
{
    public class KullaniciConfiguration : BaseEntityConfiguration<Kullanici>
    {
        public override void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.TcNo).HasMaxLength(11);
            builder.Property(p => p.Email).HasMaxLength(50);
        }
    }
}
