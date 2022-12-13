using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelMotel.Entities.Entities.Abstract;

namespace OtelMotel.DAL.EntityTypeConfiguration
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.Id);
            builder.Property(p => p.CreateDate).HasDefaultValue(new DateTime());

        }
    }
}

