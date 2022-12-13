using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelMotel.Entities.Entities.Concrete;

namespace OtelMotel.DAL.EntityTypeConfiguration
{
    public class OdaFiyatConfiguration : BaseEntityConfiguration<OdaFiyat>
    {
        public override void Configure(EntityTypeBuilder<OdaFiyat> builder)
        {
            base.Configure(builder);
        }
    }
}
