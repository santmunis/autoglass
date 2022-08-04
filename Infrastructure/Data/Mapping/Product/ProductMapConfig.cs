using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping.Product
{
    public class ProductMapConfig : IEntityTypeConfiguration<Domain.Product.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Product.Product> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(c => c.Description).IsRequired();

            builder.HasQueryFilter(entity => entity.DeletedAt == DateTimeOffset.MinValue);

        }
    }
}
