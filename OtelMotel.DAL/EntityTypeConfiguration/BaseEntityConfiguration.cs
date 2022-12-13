using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.DAL.EntityTypeConfiguration
{
    public abstract class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public virtual void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.Property(p => p.Id).HasDefaultValue(new Guid());
            builder.Property(p => p.CreateDate).HasDefaultValue(new DateTime());
            builder.Property(p => p.Status).HasDefaultValue(1);
        }
    }
}
