﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelMotel.Entities.Entities.Concrete;

namespace OtelMotel.DAL.EntityTypeConfiguration
{
    public class RezervasyonConfiguration : BaseEntityConfiguration<Rezervasyon>
    {
        public override void Configure(EntityTypeBuilder<Rezervasyon> builder)
        {
            base.Configure(builder);
            builder.HasOne(p => p.Oda)
                .WithMany(p => p.Rezervasyonlari)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.OdaFiyat)
                .WithMany(p => p.Rezervasyonlari)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(p => p.Kullanici).WithMany(p => p.Rezervasyonlar).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
