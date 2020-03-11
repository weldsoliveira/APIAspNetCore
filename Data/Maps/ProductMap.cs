using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;
using System;

namespace ProductCatalog.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000).HasColumnType("varchar(1000)");
            builder.Property(x => x.LastUpdateDate);
            builder.Property(x => x.Price).IsRequired().HasColumnType("money");
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.HasOne(x => x.Category).WithMany(x => x.Products);
        }
    }
}