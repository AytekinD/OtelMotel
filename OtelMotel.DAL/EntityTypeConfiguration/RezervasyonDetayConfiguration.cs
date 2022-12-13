using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelMotel.Entities.Entities.Concrete;

namespace OtelMotel.DAL.EntityTypeConfiguration
{
    public class REzervasyonDetayConfiguration : BaseEntityConfiguration<RezervasyonDetay>
    {
        public override void Configure(EntityTypeBuilder<RezervasyonDetay> builder)
        {
            base.Configure(builder);
            builder.HasOne(p => p.Rezervasyon)
                .WithMany(p => p.RezervasyonDetaylari)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.Kullanici).WithMany(p => p.RezervasyonDetaylari).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
