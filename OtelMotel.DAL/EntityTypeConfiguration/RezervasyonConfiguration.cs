using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelMotel.Entities.Entities.Concrete;

namespace OtelMotel.DAL.EntityTypeConfiguration
{
    public class RezervasyonConfiguration : BaseEntityConfiguration<Rezervasyon>
    {
        public override void Configure(EntityTypeBuilder<Rezervasyon> builder)
        {
            base.Configure(builder);
        }
    }
}
