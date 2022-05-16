using System;
using System.Collections.Generic;
using System.Text;

using AppVenta.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVentas.Infraestructura.Datos.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("ProductTable");
            builder.HasKey(key => key.productId);

            builder
                .HasMany(Product => Product.SaleDetails)
                .WithOne(SaleDetail => SaleDetail.Product);
            
        }
    }
}
