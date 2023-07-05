using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations
{
    public class ProductConfig : BaseConfig<Product>, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(false);


            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.Property(p => p.ManufactureEmail).IsRequired().HasMaxLength(25);

            builder.Property(p => p.ProduceDate).IsRequired().HasDefaultValueSql("GetDate()");

            builder.HasIndex(x => new { x.ManufactureEmail, x.ProduceDate }).IsUnique();

            base.Configure(builder);
        }
    }
}
